using AlmacenApplication.Dtos.Inventario;
using AlmacenApplication.Dtos.Kardex;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Services;
using InventarioApplication.Interfaces;

namespace AlmacenApplication.Services
{
    public class InventariosService : BaseService<IInventarioRepository, Inventario, long, InventarioDto>, IInventarioService
    {
        readonly IKardexRepository _repository;
        readonly IEstadoService _estadoService;
        readonly IConfiguracionService _configuracionService;
        readonly IAlmacenService _almacenService;
        readonly IUsuarioService _usuarioService;

        public InventariosService(IEstadoService estadoService, IConfiguracionService configuracionService, IKardexRepository kardexRepository, IInventarioRepository repository,
            IMapper mapper, IAlmacenService almacenService, IUsuarioService usuarioService) : base(repository, mapper)
        {
            _repository = kardexRepository;
            _estadoService = estadoService;
            _configuracionService = configuracionService;
            _almacenService = almacenService;
            _usuarioService = usuarioService;
        }

        public KardexDto ObtenerKardex(DateTime fecha, long idAlmacen) => Ejecutaconsulta(fecha, idAlmacen, false);

        public KardexDto ObtenerBajoStock(DateTime fecha, long idAlmacen) => Ejecutaconsulta(fecha, idAlmacen, true);

        public KardexDto ObtenerDiferencias(long idInventario)
        {
            var inventario = Repository.GetById(idInventario) ?? throw new Exception($"No se ha encontrado un inventario con el ID: {idInventario}");
            var almacen = _almacenService.GetById(inventario.IdAlmacen);

            if (!inventario.FechaFin.HasValue)
                throw new Exception($"El inventario ID: {idInventario} en el almacén {almacen.Nombre} aun no se ha finalizado.");

            var kardex = ObtenerKardex(DateTime.Now, almacen.Id.Value);
            var result = new KardexDto(DateTime.Now, new ElementoKardexDto(almacen.Id.Value, almacen.Nombre));

            foreach(var detalleKardex in kardex.Detalles)
            {
                var detalle = new DetalleKardexDto {
                    Producto = new ElementoKardexDto(detalleKardex.Producto.Id, detalleKardex.Producto.Nombre),
                    Unidad = new ElementoKardexDto(detalleKardex.Unidad.Id, detalleKardex.Unidad.Nombre),
                    Existencia = detalleKardex.Existencia
                };
                var detalleInventario = inventario.Detalles.FirstOrDefault(x => x.IdProducto == detalleKardex.Producto.Id && x.IdUnidad == detalleKardex.Unidad.Id);
                if (detalleInventario != null)
                    result.Detalles.Add(detalle);

                detalle.Existencia -= detalleInventario.Cantidad;
                if (detalle.Existencia != 0)
                    result.Detalles.Add(detalle);
            }

            return result;
        }

        public KardexDto Ejecutaconsulta(DateTime fecha, long idAlmacen, bool soloBajoStock)
        {
            var estadoEntrada = _estadoService.PorSeccion("ENTRADA DE ALMACEN")?.FirstOrDefault(e => e.Nombre.Equals("AUTORIZADO", StringComparison.InvariantCultureIgnoreCase));
            var estadoSalida = _estadoService.PorSeccion("SALIDA DE ALMACEN")?.FirstOrDefault(e => e.Nombre.Equals("AUTORIZADO", StringComparison.InvariantCultureIgnoreCase));
            var stockMinimo = 0;
            if (soloBajoStock) {
                var configuracion = _configuracionService.PorNombre("sotck_minimo") ?? throw new Exception("No existe una configuracion para stock mínimo.");
                if (!int.TryParse(configuracion.Valor, out stockMinimo))
                    stockMinimo = 5;
            }

            if (estadoEntrada == null)
                throw new Exception("No existe un estado AUTORIZADO para la seccion ENTRADA DE ALMACEN.");

            if (estadoSalida == null)
                throw new Exception("No existe un estado AUTORIZADO para la seccion SALIDA DE ALMACEN.");

            var kardex = _repository.GetKardex(idAlmacen, fecha, estadoEntrada.Id.Value, estadoSalida.Id.Value);
            if (kardex.Count <= 0)
                return null;

            var result = new KardexDto(fecha, new ElementoKardexDto(kardex.First().IdAlmacen, kardex.First().Almacen));
            result.Detalles = kardex
                .GroupBy(k => new { k.IdProducto, k.IdUnidad })
                .Select(k => {
                    var detalle = new DetalleKardexDto();
                    detalle.Entradas = CrearMovimientos(k.Where(itm => itm.FechaEntrada.HasValue).ToList(), true);
                    detalle.Salidas = CrearMovimientos(k.Where(itm => itm.FechaSalida.HasValue).ToList(), false);
                    detalle.Producto = new ElementoKardexDto(k.First().IdProducto, k.First().Producto);
                    detalle.Unidad = new ElementoKardexDto(k.First().IdUnidad, k.First().Unidad);
                    detalle.Existencia = detalle.Entradas.Sum(e => e.Cantidad) - detalle.Salidas.Sum(e => e.Cantidad);
                    if (soloBajoStock && detalle.Existencia >= stockMinimo)
                        return null;

                    return detalle;
                }).ToList();

            result.Detalles = result.Detalles.Where(d => d != null).ToList();
            foreach (var detalle in result.Detalles.Where(d => d.Existencia <= 0))
            {
                if (detalle.Existencia == 0)
                    result.SinExistencias.Add(new Tuple<ElementoKardexDto, ElementoKardexDto>(detalle.Producto, detalle.Unidad));
                else
                    result.ExistenciasNegativas.Add(new Tuple<ElementoKardexDto, ElementoKardexDto>(detalle.Producto, detalle.Unidad));
            }

            _repository.ClearTracker(true);

            return result;
        }

        private static List<MovimientoKardexDto> CrearMovimientos(List<Kardex> kardex, bool esEntrada) => kardex.Select(itm => new MovimientoKardexDto
        {
            IdProducto = itm.IdProducto,
            IdAlmacen = itm.IdAlmacen,
            IdUnidad = itm.IdUnidad,
            Cantidad = esEntrada ? itm.Entrada.Value : itm.Salida.Value,
            Fecha = esEntrada ? itm.FechaEntrada.Value : itm.FechaSalida.Value,
            Concepto = new ElementoKardexDto(itm.IdConcepto, itm.Concepto),
            Estado = new ElementoKardexDto(itm.IdEstado, itm.Estado)
        }).ToList();

        protected override void Validaciones(InventarioDto dto)
        {
            var almacen = _almacenService.GetById(dto.IdAlmacen) ?? throw new Exception($"No existe un almacén con ID: {dto.IdAlmacen}.");
            dto.IdAlmacen = almacen.Id.Value;

            var usuarioInicio = _usuarioService.GetById(dto.IdUsuarioInicio) ?? throw new Exception($"No existe un usuario con ID: {dto.IdUsuarioInicio}");
            dto.IdUsuarioInicio = usuarioInicio.Id.Value;

            if (dto.IdUsuarioFin.HasValue)
            {
                var usuarioFin = _usuarioService.GetById(dto.IdUsuarioFin.Value) ?? throw new Exception($"No existe un usuario con ID: {dto.IdUsuarioFin}");
                dto.IdUsuarioFin = usuarioFin.Id.Value;
            }

            if (dto.FechaInicio > DateTime.Now)
                throw new Exception("La fecha de inicio de inventario no puede ser mayor a la fecha en curso.");

            if (dto.FechaFin.HasValue && dto.FechaFin.Value > DateTime.Now)
                throw new Exception("La fecha de fin de inventario no puede ser mayor a la fecha en curso.");

            Repository.ClearTracker(true);
        }
    }
}

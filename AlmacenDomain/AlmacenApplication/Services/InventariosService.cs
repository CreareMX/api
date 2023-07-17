using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;

namespace AlmacenApplication.Services
{
    public class InventariosService : IInventariosService
    {
        readonly IEntradaAlmacenService _entradaAlmacen;
        readonly ISalidaAlmacenService _salidaAlmacen;
        readonly IAlmacenService _almacenService;
        readonly IEstadoService _estadoService;
        readonly IProductoService _productoService;
        readonly IUnidadService _unidadService;
        readonly IMapper _mapper;

        public InventariosService(IEntradaAlmacenService entradaAlmacen, ISalidaAlmacenService salidaAlmacen, IAlmacenService almacenService, 
            IEstadoService estadoService, IProductoService productoService, IUnidadService unidadService, IMapper mapper)
        {
            _entradaAlmacen = entradaAlmacen;
            _salidaAlmacen = salidaAlmacen;
            _almacenService = almacenService;
            _estadoService = estadoService;
            _productoService = productoService;
            _unidadService = unidadService;
            _mapper = mapper;
        }

        public KardexDto ObtenerKardex(DateTime fecha, long idAlmacen)
        {
            var estadoActivo = _estadoService.PorSeccion("almacen").FirstOrDefault(e => e.Nombre.Equals("autorizado", StringComparison.InvariantCultureIgnoreCase)) ?? 
                throw new Exception("No se ha ocnfigurado un estado ACTIVO para la sección ALMACEN.");
            var almacen = _almacenService.GetById(idAlmacen) ?? throw new Exception($"No existe el almacen con ID: {idAlmacen}.");
            var entradas = _entradaAlmacen.PorAlmacen(idAlmacen).Where(e => e.IdEstado == estadoActivo.Id).ToList();
            var salidas = _salidaAlmacen.PorAlmacen(idAlmacen).Where(s => s.IdEstado == estadoActivo.Id).ToList();

            var idProductos = entradas.Select(e => $"{e.IdProducto}-{e.IdUnidad}").ToList();
            idProductos.AddRange(salidas.Select(s => $"{s.IdProducto}-{s.IdUnidad}"));
            idProductos = idProductos.Distinct().ToList();

            var kardex = new KardexDto(fecha, almacen);
            foreach(var idProducto in idProductos)
            {
                var ids = idProducto.Split('-').Select(id => long.Parse(id));
                var detalle = CreaDetalle(ids.First(), ids.Last(), fecha, entradas, salidas);
                if (detalle.Existencia < 0)
                    kardex.ExistenciasNegativas.Add(new Tuple<ProductoDto, UnidadDto>(detalle.Producto, detalle.Unidad));
                else if (detalle.Existencia == 0)
                    kardex.SinExistencias.Add(new Tuple<ProductoDto, UnidadDto>(detalle.Producto, detalle.Unidad));

                kardex.Detalles.Add(detalle);
            }

            return kardex;
        }

        private DetalleKardexDto CreaDetalle(long idProducto, long idUnidad, DateTime fecha, List<EntradaAlmacenDto> entradas, List<SalidaAlmacenDto> salidas)
        {
            var detalle = new DetalleKardexDto();
            var entradasProducto = entradas.Where(e => e.IdProducto == idProducto && e.IdUnidad == idUnidad && e.FechaEntrada <= fecha);
            var salidasProducto = salidas.Where(s => s.IdProducto == idProducto && s.IdUnidad == idUnidad && s.FechaSalida <= fecha);
            if (entradasProducto == null)
            {
                var salida = salidasProducto.First();
                detalle.Producto = _productoService.GetById(salida.IdProducto);
                detalle.Unidad = _unidadService.GetById(salida.IdUnidad);
            }
            else
            {
                var entrada = entradasProducto.First();
                detalle.Producto = _productoService.GetById(entrada.IdProducto);
                detalle.Unidad = _unidadService.GetById(entrada.IdUnidad);
            }

            detalle.Entradas.AddRange(entradasProducto);
            detalle.Salidas.AddRange(salidasProducto);
            detalle.Existencia = entradas.Sum(e => e.Cantidad) - salidas.Sum(s => s.Cantidad);
            return detalle;
        }
    }
}

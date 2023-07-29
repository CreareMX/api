using AlmacenApplication.Dtos.Kardex;
using AlmacenApplication.Interfaces;
using CommonApplication.Interfaces;
using CommonCore.Interfaces.Repositories.Warehouse;

namespace AlmacenApplication.Services
{
    public class InventariosService : IInventariosService
    {
        readonly IKardexRepository _repository;
        readonly IEstadoService _estadoService;

        public InventariosService(IEstadoService estadoService, IKardexRepository repository)
        {
            _repository = repository;
            _estadoService = estadoService;
        }

        public KardexDto ObtenerKardex(DateTime fecha, long idAlmacen)
        {
            var estadoEntrada = _estadoService.PorSeccion("ENTRADA DE ALMACEN")?.FirstOrDefault(e => e.Nombre.Equals("AUTORIZADO", StringComparison.InvariantCultureIgnoreCase));
            var estadoSalida = _estadoService.PorSeccion("SALIDA DE ALMACEN")?.FirstOrDefault(e => e.Nombre.Equals("AUTORIZADO", StringComparison.InvariantCultureIgnoreCase));

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
                    detalle.Entradas = k.Where(itm => itm.FechaEntrada.HasValue)
                                        .Select(itm => new MovimientoKardexDto
                                        {
                                            IdProducto = itm.IdProducto,
                                            IdAlmacen = itm.IdAlmacen,
                                            IdUnidad = itm.IdUnidad,
                                            Cantidad = itm.Entrada.Value,
                                            Fecha = itm.FechaEntrada.Value,
                                            Concepto = new ElementoKardexDto(itm.IdConcepto, itm.Concepto),
                                            Estado = new ElementoKardexDto(itm.IdEstado, itm.Estado)
                                        }).ToList();

                    detalle.Salidas = k.Where(itm => itm.FechaSalida.HasValue).Select(itm => new MovimientoKardexDto
                    {
                        IdProducto = itm.IdProducto,
                        IdAlmacen = itm.IdAlmacen,
                        IdUnidad = itm.IdUnidad,
                        Cantidad = itm.Salida.Value,
                        Fecha = itm.FechaSalida.Value,
                        Concepto = new ElementoKardexDto(itm.IdConcepto, itm.Concepto),
                        Estado = new ElementoKardexDto(itm.IdEstado, itm.Estado)
                    }).ToList();

                    detalle.Producto = new ElementoKardexDto(k.First().IdProducto, k.First().Producto);
                    detalle.Unidad = new ElementoKardexDto(k.First().IdUnidad, k.First().Unidad);
                    detalle.Existencia = detalle.Entradas.Sum(e => e.Cantidad) - detalle.Salidas.Sum(e => e.Cantidad);

                    return detalle;
                }).ToList();

            foreach(var detalle in result.Detalles.Where(d => d.Existencia <= 0))
            {
                if (detalle.Existencia == 0)
                    result.SinExistencias.Add(new Tuple<ElementoKardexDto, ElementoKardexDto>(detalle.Producto, detalle.Unidad));
                else
                    result.ExistenciasNegativas.Add(new Tuple<ElementoKardexDto, ElementoKardexDto>(detalle.Producto, detalle.Unidad));
            }

            _repository.ClearTracker(true);

            return result;
        }

        public KardexDto ObtenerBajoStock(DateTime fecha, long idAlmacen)
        {
            throw new NotImplementedException();
            //var estadoActivo = _estadoService.PorSeccion("almacen").FirstOrDefault(e => e.Nombre.Equals("autorizado", StringComparison.InvariantCultureIgnoreCase)) ??
            //    throw new Exception("No se ha ocnfigurado un estado ACTIVO para la sección ALMACEN.");
            //var almacen = _almacenService.GetById(idAlmacen) ?? throw new Exception($"No existe el almacen con ID: {idAlmacen}.");
            //var entradas = _entradaAlmacen.PorAlmacen(idAlmacen).Where(e => e.IdEstado == estadoActivo.Id).ToList();
            //var salidas = _salidaAlmacen.PorAlmacen(idAlmacen).Where(s => s.IdEstado == estadoActivo.Id).ToList();

            //var idProductos = entradas.Select(e => $"{e.IdProducto}-{e.IdUnidad}").ToList();
            //idProductos.AddRange(salidas.Select(s => $"{s.IdProducto}-{s.IdUnidad}"));
            //idProductos = idProductos.Distinct().ToList();

            //var kardex = new KardexDto(fecha, almacen);
            //foreach (var idProducto in idProductos)
            //{
            //    var ids = idProducto.Split('-').Select(id => long.Parse(id));
            //    var detalle = CreaDetalle(ids.First(), ids.Last(), fecha, entradas, salidas, true);
            //    if (detalle.Existencia < 0)
            //        kardex.ExistenciasNegativas.Add(new Tuple<ProductoDto, UnidadDto>(detalle.Producto, detalle.Unidad));
            //    else if (detalle.Existencia == 0)
            //        kardex.SinExistencias.Add(new Tuple<ProductoDto, UnidadDto>(detalle.Producto, detalle.Unidad));

            //    kardex.Detalles.Add(detalle);
            //}
            //_repository.ClearTracker(true);

            //return kardex;
        }
    }
}

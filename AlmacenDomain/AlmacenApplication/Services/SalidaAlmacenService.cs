using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Criterias.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Services;

namespace AlmacenApplication.Services
{
    internal class SalidaAlmacenService : BaseService<ISalidaAlmacenRepository, SalidaAlmacen, long, SalidaAlmacenDto>, ISalidaAlmacenService
    {
        readonly IProductoService productoService;
        readonly IAlmacenService almacenService;
        readonly IUnidadService unidadService;
        readonly ISeccionService seccionService;
        readonly IEstadoService estadoService;
        readonly IConceptoService conceptoService;
        readonly ISalidaAlmacenCriteria salidaAlmacenCriteria;

        public SalidaAlmacenService(ISalidaAlmacenRepository repository, IProductoService productoService,
            IAlmacenService almacenService, IUnidadService unidadService, ISeccionService seccionService,
            IEstadoService estadoService, IConceptoService conceptoService, ISalidaAlmacenCriteria salidaAlmacenCriteria, 
            IMapper mapper) : base(repository, mapper)
        {
            this.productoService = productoService;
            this.almacenService = almacenService;
            this.unidadService = unidadService;
            this.seccionService = seccionService;
            this.estadoService = estadoService;
            this.conceptoService = conceptoService;
            this.salidaAlmacenCriteria = salidaAlmacenCriteria;
        }
        public List<SalidaAlmacenDto> PorAlmacen(long idAlmacen)
        {
            var result = Repository.GetListByCriteria(salidaAlmacenCriteria.PorAlmacen(idAlmacen));
            Repository.ClearTracker(true);
            if (result == null || result.Count == 0)
                return null;
            
            return Mapper.Map<List<SalidaAlmacenDto>>(result);
        }
        public void ActualizaEstado(long idEntrada, long idEstado, long idUsuario)
        {
            var entity = Repository.GetById(idEntrada) ?? throw new Exception($"No se ha encontrado la salida con ID: {idEntrada}.");
            var seccion = seccionService.PorSeccion("ALMACEN") ?? throw new Exception("No se ha creado la seccion ALMACEN.");
            var estatus = this.estadoService.GetById(idEstado) ?? throw new Exception("No se ha selecionado un estado para la salida.");

            if (estatus.IdSeccion != seccion.Id)
                throw new Exception($"El estado {estatus.Nombre} no pertenece a la seccion {seccion.Nombre}.");

            Repository.ClearTracker(true);

            entity.IdEstado = estatus.Id.Value;
            entity.Update(idUsuario);
            Repository.SaveChanges();
            Repository.ClearTracker(true);
        }
        protected override void Validaciones(SalidaAlmacenDto dto)
        {
            base.Validaciones(dto);

            var producto = this.productoService.GetById(dto.IdProducto) ?? throw new Exception("No se ha selecionado un producto.");
            dto.IdProducto = producto.Id.Value;

            var almacen = this.almacenService.GetById(dto.IdAlmacen) ?? throw new Exception("No se ha selecionado un almancén.");
            dto.IdAlmacen = almacen.Id.Value;

            var unidad = this.unidadService.GetById(dto.IdUnidad) ?? throw new Exception("No se ha selecionado una unidad de producto.");
            dto.IdUnidad = unidad.Id.Value;

            var seccion = seccionService.PorSeccion("ALMACEN") ?? throw new Exception("No se ha creado la seccion ALMACEN.");
            var estatus = this.estadoService.GetById(dto.IdEstado) ?? throw new Exception("No se ha selecionado un estado para la salida.");
            dto.IdEstado = estatus.Id.Value;

            if (estatus.IdSeccion != seccion.Id)
                throw new Exception($"El estado {estatus.Nombre} no pertenece a la seccion {seccion.Nombre}.");

            var conceptos = this.conceptoService.PorSeccion("SALIDA DE ALMACEN") ?? throw new Exception("No se ha creado la sección SALIDA DE ALMACEN");
            if (!conceptos.Any(c => c.Id == dto.IdConcepto))
                throw new Exception($"No existe un concepto con ID {dto.IdConcepto}");
        }
    }
}

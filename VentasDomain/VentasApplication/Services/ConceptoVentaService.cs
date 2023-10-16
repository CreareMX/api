using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Repositories.Sales;
using CommonCore.Services;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;

namespace VentasApplication.Services
{
    internal class ConceptoVentaService : BaseService<IConceptoVentaRepository, ConceptoVenta, long, ConceptoVentaDto>, IConceptoVentaService
    {
        readonly IProductoService productoService;
        readonly IImpuestosConceptoVentaService impuestosConceptoVentaService;
        public ConceptoVentaService(IConceptoVentaRepository repository, IProductoService _productoService, IImpuestosConceptoVentaService _impuestosConceptoVentaService,
            IMapper mapper) : base(repository, mapper)
        {
            productoService = _productoService;
            impuestosConceptoVentaService = _impuestosConceptoVentaService;
        }

        public override ConceptoVentaDto Create(ConceptoVentaDto dto, long idUser)
        {
            return base.Create(dto, idUser);
        }

        public override void Update(ConceptoVentaDto dto, long idUser)
        {
            Validaciones(dto);
            var conceptoVenta = this.Repository.GetById(dto.Id.Value) ?? throw new Exception($"No se ha encontrado el Concepto Venta con id {dto.Id}.");
            conceptoVenta.Update(idUser);
            this.Repository.Update(conceptoVenta);
            this.Repository.SaveChanges();
            this.Repository.ClearTracker(true);
        }

        protected override void Validaciones(ConceptoVentaDto dto)
        {
            base.Validaciones(dto);
        }
    }
}

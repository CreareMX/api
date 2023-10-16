using AutoMapper;
using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Repositories.Sales;
using CommonCore.Services;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;

namespace VentasApplication.Services
{
    internal class ImpuestosConceptoVentaService : BaseService<IImpuestosConceptoVentaRepository, ImpuestosConceptoVenta, long, ImpuestosConceptoVentaDto>, IImpuestosConceptoVentaService
    {
        public ImpuestosConceptoVentaService(IImpuestosConceptoVentaRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override ImpuestosConceptoVentaDto Create(ImpuestosConceptoVentaDto dto, long idUser)
        {
            return base.Create(dto, idUser);
        }

        public override void Update(ImpuestosConceptoVentaDto dto, long idUser)
        {
            Validaciones(dto);
            var impuestosConceptoVenta = this.Repository.GetById(dto.Id.Value) ?? throw new Exception($"No se ha encontrado el Impuesto del Concepto de Venta con id {dto.Id}.");
            impuestosConceptoVenta.Update(idUser);
            this.Repository.Update(impuestosConceptoVenta);
            this.Repository.SaveChanges();
            this.Repository.ClearTracker(true);
        }

        protected override void Validaciones(ImpuestosConceptoVentaDto dto)
        {
            base.Validaciones(dto);
        }
    }
}

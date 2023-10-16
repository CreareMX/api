using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Repositories.Sales;
using CommonCore.Services;
using ContabilidadApplication.Interfaces;
using VentasApplication.Dtos;
using VentasApplication.Interfaces;

namespace VentasApplication.Services
{
    internal class VentaService : BaseService<IVentaRepository, Venta, long, VentaDto>, IVentaService
    {
        readonly IPersonaService personaService;
        readonly ISucursalService sucursalService;
        readonly IConceptoVentaService conceptoVentaService;
        public VentaService(IVentaRepository repository, IPersonaService _personaService, ISucursalService _sucursalService,
            IConceptoVentaService _conceptoVentaService, IMapper mapper) : base(repository, mapper)
        {
            personaService = _personaService;
            sucursalService = _sucursalService;
            conceptoVentaService = _conceptoVentaService;
        }

        public override VentaDto Create(VentaDto dto, long idUser)
        {
            return base.Create(dto, idUser);
        }

        public override void Update(VentaDto dto, long idUser)
        {
            Validaciones(dto);
            var venta = this.Repository.GetById(dto.Id.Value) ?? throw new Exception($"No se ha encontrado la Venta con id {dto.Id}.");
            venta.Update(idUser);
            this.Repository.Update(venta);
            this.Repository.SaveChanges();
            this.Repository.ClearTracker(true);
        }

        protected override void Validaciones(VentaDto dto)
        {
            base.Validaciones(dto);
        }
    }
}

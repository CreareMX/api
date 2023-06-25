using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;

namespace ContabilidadApplication.Services
{
    public class CuentaPorPagarService : BaseService<ICuentaPorPagarRepository, CuentaPorPagar, long, CuentaPorPagarDto>, ICuentaPorPagarService
    {
        private readonly IEstadoService estadoService;
        private readonly IPersonaService personaService;
        public CuentaPorPagarService(ICuentaPorPagarRepository repository, IEstadoService estadoService, IPersonaService personaService, IMapper mapper) : base(repository, mapper)
        {
            this.estadoService = estadoService;
            this.personaService = personaService;
        }

        public override CuentaPorPagarDto Create(CuentaPorPagarDto dto, long idUser)
        {
            var estado = estadoService.GetById(dto.IdEstado) ?? throw new Exception("No se ha establecido un estado para la cuenta por Pagar.");
            dto.IdEstado = estado.Id.Value;

            var Proveedor = personaService.GetById(dto.IdProveedor) ?? throw new Exception("No se ha establecido un Proveedor para la cuenta por Pagar.");
            dto.IdProveedor = Proveedor.Id.Value;

            if (!Proveedor.TipoPersona.Nombre.ToUpper().Contains("PROVEEDOR"))
                throw new Exception("La persona seleccionada no es un Proveedor.");

            if (dto.Monto <= 0)
                throw new Exception("El monto de una cuenta por Pagar no debe ser menor o igual a cero");

            if (dto.Saldo <= 0)
                throw new Exception("El saldo inicial de una cuenta por Pagar no debe ser menor o igual a cero");

            return base.Create(dto, idUser);
        }
    }
}

using AutoMapper;
using CommonApplication.Interfaces;
using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;

namespace ContabilidadApplication.Services
{
    public class CuentaPorCobrarService : BaseService<ICuentaPorCobrarRepository, CuentaPorCobrar, long, CuentaPorCobrarDto>, ICuentaPorCobrarService
    {
        private readonly IEstadoService estadoService;
        private readonly IPersonaService personaService;
        public CuentaPorCobrarService(ICuentaPorCobrarRepository repository, IEstadoService estadoService, IPersonaService personaService, IMapper mapper) : base(repository, mapper)
        {
            this.estadoService = estadoService;
            this.personaService = personaService;
        }

        public override CuentaPorCobrarDto Create(CuentaPorCobrarDto dto, long idUser)
        {
            var estado = estadoService.GetById(dto.IdEstado) ?? throw new Exception("No se ha establecido un estado para la cuenta por cobrar.");
            dto.IdEstado = estado.Id.Value;

            var cliente = personaService.GetById(dto.IdCliente) ?? throw new Exception("No se ha establecido un cliente para la cuenta por cobrar.");
            dto.IdCliente = cliente.Id.Value;

            if (!cliente.TipoPersona.Nombre.ToUpper().Contains("CLIENTE"))
                throw new Exception("La persona seleccionada no es un cliente.");

            if (dto.Monto <= 0)
                throw new Exception("El monto de una cuenta por cobrar no debe ser menor o igual a cero");

            if (dto.Saldo <= 0)
                throw new Exception("El saldo inicial de una cuenta por cobrar no debe ser menor o igual a cero");

            return base.Create(dto, idUser);
        }
    }
}

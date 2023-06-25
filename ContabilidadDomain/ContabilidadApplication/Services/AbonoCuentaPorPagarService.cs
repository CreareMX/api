using AutoMapper;
using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;

namespace ContabilidadApplication.Services
{
    public class AbonoCuentaPorPagarService : BaseService<IAbonoCuentaPorPagarRepository, AbonoCuentaPorPagar, long, AbonoCuentaPorPagarDto>, IAbonoCuentaPorPagarService
    {
        private readonly ICuentaPorPagarService cuentaPorPagarService;

        public AbonoCuentaPorPagarService(IAbonoCuentaPorPagarRepository repository, ICuentaPorPagarService cuentaPorPagarService, IMapper mapper) : base(repository, mapper)
        {
            this.cuentaPorPagarService = cuentaPorPagarService;
        }

        public override AbonoCuentaPorPagarDto Create(AbonoCuentaPorPagarDto dto, long idUser)
        {
            var cuentaPorPagar = cuentaPorPagarService.GetById(dto.IdCuentaPorPagar) ?? throw new Exception("No se ha establecido la cuenta por Pagar para la cual se realizará el abono.");
            dto.IdCuentaPorPagar = cuentaPorPagar.Id.Value;

            if (dto.Monto <= 0)
                throw new Exception("El monto de un abono no debe ser menor o igual a cero");

            if(dto.Monto > cuentaPorPagar.Saldo)
                throw new Exception($"No se puede hace un abono por una cantidad mayor al saldo de la cuenta por Pagar (${cuentaPorPagar.Saldo}");

            var result =  base.Create(dto, idUser);

            cuentaPorPagar.Saldo -= dto.Monto;
            cuentaPorPagarService.Update(cuentaPorPagar, idUser);

            return result;
        }
    }
}

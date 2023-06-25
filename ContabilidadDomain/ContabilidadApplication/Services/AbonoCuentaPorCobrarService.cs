using AutoMapper;
using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using EssentialCore.Services;

namespace ContabilidadApplication.Services
{
    public class AbonoCuentaPorCobrarService : BaseService<IAbonoCuentaPorCobrarRepository, AbonoCuentaPorCobrar, long, AbonoCuentaPorCobrarDto>, IAbonoCuentaPorCobrarService
    {
        private readonly ICuentaPorCobrarService cuentaPorCobrarService;

        public AbonoCuentaPorCobrarService(IAbonoCuentaPorCobrarRepository repository, ICuentaPorCobrarService cuentaPorCobrarService, IMapper mapper) : base(repository, mapper)
        {
            this.cuentaPorCobrarService = cuentaPorCobrarService;
        }

        public override AbonoCuentaPorCobrarDto Create(AbonoCuentaPorCobrarDto dto, long idUser)
        {
            var cuentaPorCobrar = cuentaPorCobrarService.GetById(dto.IdCuentaPorCobrar) ?? throw new Exception("No se ha establecido la cuenta por cobrar para la cual se realizará el abono.");
            dto.IdCuentaPorCobrar = cuentaPorCobrar.Id.Value;

            if (dto.Monto <= 0)
                throw new Exception("El monto de un abono no debe ser menor o igual a cero");

            if(dto.Monto > cuentaPorCobrar.Saldo)
                throw new Exception($"No se puede hace un abono por una cantidad mayor al saldo de la cuenta por cobrar (${cuentaPorCobrar.Saldo}");

            var result =  base.Create(dto, idUser);

            cuentaPorCobrar.Saldo -= dto.Monto;
            cuentaPorCobrarService.Update(cuentaPorCobrar, idUser);

            return result;
        }
    }
}

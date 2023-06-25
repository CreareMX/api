using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using EssentialCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface IAbonoCuentaPorCobrarService : IService<IAbonoCuentaPorCobrarRepository, AbonoCuentaPorCobrar, long, AbonoCuentaPorCobrarDto>
    {
    }
}

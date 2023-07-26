using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using CommonCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface IAbonoCuentaPorCobrarService : IService<IAbonoCuentaPorCobrarRepository, AbonoCuentaPorCobrar, long, AbonoCuentaPorCobrarDto>
    {
    }
}

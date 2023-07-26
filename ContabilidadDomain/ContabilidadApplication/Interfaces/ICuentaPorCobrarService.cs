using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using CommonCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface ICuentaPorCobrarService : IService<ICuentaPorCobrarRepository, CuentaPorCobrar, long, CuentaPorCobrarDto>
    {
    }
}

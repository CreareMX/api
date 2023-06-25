using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using ContabilidadApplication.Dtos;
using EssentialCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface ICuentaPorPagarService : IService<ICuentaPorPagarRepository, CuentaPorPagar, long, CuentaPorPagarDto>
    {
    }
}

using ContabilidadApplication.Dtos;
using ContabilidadCore.Entities;
using ContabilidadCore.Interfaces.Reporitories;
using EssentialCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface IAbonoCuentaPorPagarService : IService<IAbonoCuentaPorPagarRepository, AbonoCuentaPorPagar, long, AbonoCuentaPorPagarDto>
    {
    }
}

using AlmacenApplication.Dtos;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface ISalidaAlmacenService : IService<ISalidaAlmacenRepository, SalidaAlmacen, long, SalidaAlmacenDto>
    {
    }
}

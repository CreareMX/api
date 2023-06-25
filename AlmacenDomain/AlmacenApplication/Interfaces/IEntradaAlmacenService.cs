using AlmacenApplication.Dtos;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IEntradaAlmacenService : IService<IEntradaAlmacenRepository, EntradaAlmacen, long, EntradaAlmacenDto>
    {
    }
}

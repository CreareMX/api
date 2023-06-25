using AlmacenApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IAlmacenService : IService<IAlmacenRepository, Almacen, long, AlmacenDto>
    {
    }
}

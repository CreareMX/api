using AlmacenApplication.Dtos;
using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface ISalidaAlmacenService : IService<ISalidaAlmacenRepository, SalidaAlmacen, long, SalidaAlmacenDto>
    {
    }
}

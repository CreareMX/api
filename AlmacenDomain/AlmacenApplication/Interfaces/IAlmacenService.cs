using AlmacenApplication.Dtos;
using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IAlmacenService : IService<IAlmacenRepository, Almacen, long, AlmacenDto>
    {
    }
}

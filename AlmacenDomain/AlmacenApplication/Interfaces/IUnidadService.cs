using AlmacenApplication.Dtos;
using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IUnidadService : IService<IUnidadRepository, Unidad, long, UnidadDto>
    {
    }
}

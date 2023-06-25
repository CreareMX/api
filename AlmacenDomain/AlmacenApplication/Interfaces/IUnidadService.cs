using AlmacenApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IUnidadService : IService<IUnidadRepository, Unidad, long, UnidadDto>
    {
    }
}

using CommonApplication.dtos;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IPermisoService : IService<IPermisoRepository, Permiso, long, PermisoDto>
    {
    }
}

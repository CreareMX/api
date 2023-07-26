using CommonApplication.dtos;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IPermisosRolService : IService<IPermisosRolRepository, PermisosRol, long, PermisosRolDto>
    {
    }
}

using EssentialApplication.dtos;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace EssentialApplication.Interfaces
{
    public interface IRolService : IService<IRolRepository, Rol, long, RolDto>
    {
    }
}

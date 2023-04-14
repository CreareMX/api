using AutoMapper;
using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace EssentialApplication.Services
{
    public class PermisosRolService : BaseService<IPermisosRolRepository, PermisosRol, long, PermisosRolDto>, IPermisosRolService
    {
        public PermisosRolService(IPermisosRolRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

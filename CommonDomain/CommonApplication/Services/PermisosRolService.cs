using AutoMapper;
using CommonApplication.dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Services;

namespace CommonApplication.Services
{
    public class PermisosRolService : BaseService<IPermisosRolRepository, PermisosRol, long, PermisosRolDto>, IPermisosRolService
    {
        public PermisosRolService(IPermisosRolRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

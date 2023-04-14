using AutoMapper;
using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace EssentialApplication.Services
{
    public class RolService : BaseService<IRolRepository, Rol, long, RolDto>, IRolService
    {
        public RolService(IRolRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

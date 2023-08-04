using AutoMapper;
using CommonApplication.dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Services;

namespace CommonApplication.Services
{
    public class RolService : BaseService<IRolRepository, Rol, long, RolDto>, IRolService
    {
        public RolService(IRolRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

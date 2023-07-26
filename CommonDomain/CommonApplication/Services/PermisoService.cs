using AutoMapper;
using CommonApplication.dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Services;

namespace CommonApplication.Services
{
    public class PermisoService : BaseService<IPermisoRepository, Permiso, long, PermisoDto>, IPermisoService
    {
        public PermisoService(IPermisoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

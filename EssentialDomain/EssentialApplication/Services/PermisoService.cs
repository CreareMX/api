using AutoMapper;
using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace EssentialApplication.Services
{
    public class PermisoService : BaseService<IPermisoRepository, Permiso, long, PermisoDto>, IPermisoService
    {
        public PermisoService(IPermisoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

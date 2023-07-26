using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using CommonCore.Services;

namespace AlmacenApplication.Services
{
    internal class TipoAlmacenService : BaseService<ITipoAlmacenRepository, TipoAlmacen, long, TipoAlmacenDto>, ITipoAlmacenService
    {

        public TipoAlmacenService(ITipoAlmacenRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

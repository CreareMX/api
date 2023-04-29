using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using AutoMapper;
using EssentialCore.Services;

namespace AlmacenApplication.Services
{
    internal class TipoAlmacenService : BaseService<ITipoAlmacenRepository, TipoAlmacen, long, TipoAlmacenDto>, ITipoAlmacenService
    {

        public TipoAlmacenService(ITipoAlmacenRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

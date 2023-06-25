using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Services;

namespace AlmacenApplication.Services
{
    public class UnidadService : BaseService<IUnidadRepository, Unidad, long, UnidadDto>, IUnidadService
    {
        public UnidadService(IUnidadRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

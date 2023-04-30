using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using AutoMapper;
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

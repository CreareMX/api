using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class TipoPersonaService : BaseService<ITipoPersonaRepository, TipoPersona, long, TipoPersonaDto>, ITipoPersonaService
    {
        public TipoPersonaService(ITipoPersonaRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

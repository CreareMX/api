using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
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

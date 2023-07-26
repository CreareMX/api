using CommonApplication.Dtos;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface ITipoPersonaService : IService<ITipoPersonaRepository, TipoPersona, long, TipoPersonaDto>
    {
    }
}

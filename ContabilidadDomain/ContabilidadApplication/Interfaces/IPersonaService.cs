using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using ContabilidadApplication.Dtos;
using CommonCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface IPersonaService : IService<IPersonaRepository, Persona, long, PersonaDto>
    {
    }
}

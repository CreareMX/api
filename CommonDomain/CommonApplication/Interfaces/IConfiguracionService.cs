using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IConfiguracionService : IService<IConfiguracionRepository, Configuracion, long, ConfiguracionDto>
    {
        ConfiguracionDto PorNombre(string seccion);
    }
}

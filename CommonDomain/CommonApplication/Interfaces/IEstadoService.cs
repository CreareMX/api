using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IEstadoService : IService<IEstadoRepository, Estado, long, EstadoDto>
    {
        IList<EstadoDto> PorSeccion(string seccion);
    }
}

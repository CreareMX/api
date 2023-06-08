using CommonApplication.Dtos;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IEstadoService : IService<IEstadoRepository, Estado, long, EstadoDto>
    {
        IList<EstadoDto> PorSeccion(string seccion);
    }
}

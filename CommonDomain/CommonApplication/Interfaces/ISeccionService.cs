using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface ISeccionService : IService<ISeccionRepository, Seccion, long, SeccionDto>
    {
        SeccionDto PorSeccion(string seccion);
    }
}

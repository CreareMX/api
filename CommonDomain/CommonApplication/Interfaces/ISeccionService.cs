using CommonApplication.Dtos;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface ISeccionService : IService<ISeccionRepository, Seccion, long, SeccionDto>
    {
    }
}

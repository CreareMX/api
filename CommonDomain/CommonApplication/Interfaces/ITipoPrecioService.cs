using CommonApplication.Dtos;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using EssentialCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface ITipoPrecioService : IService<ITipoPrecioRepository, TipoPrecio, long, TipoPrecioDto>
    {
    }
}

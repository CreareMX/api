using CommonApplication.Dtos;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface ITipoPrecioService : IService<ITipoPrecioRepository, TipoPrecio, long, TipoPrecioDto>
    {
    }
}

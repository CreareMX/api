using CommonApplication.Dtos;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IPrecioService : IService<IPrecioRepository, Precio, long, PrecioDto>
    {
    }
}

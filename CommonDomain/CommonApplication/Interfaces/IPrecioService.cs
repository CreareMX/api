using CommonApplication.Dtos;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using EssentialCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IPrecioService : IService<IPrecioRepository, Precio, long, PrecioDto>
    {
    }
}

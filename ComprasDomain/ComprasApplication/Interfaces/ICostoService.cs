using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using EssentialCore.Interfaces.Service;

namespace ComprasApplication.Interfaces
{
    public interface ICostoService : IService<ICostoRepository, Costo, long, CostoDto>
    {
    }
}

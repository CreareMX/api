using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface ISucursalService : IService<ISucursalRepository, Sucursal, long, SucursalDto>
    {
    }
}

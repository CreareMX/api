using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;
using ComprasCore.Interfaces.Repositories;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IProductoService : IService<IProductoRepository, Producto, long, ProductoDto>
    {
    }
}

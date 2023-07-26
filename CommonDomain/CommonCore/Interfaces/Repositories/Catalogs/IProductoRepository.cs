using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories;

namespace ComprasCore.Interfaces.Repositories
{
    public interface IProductoRepository : IRepository<Producto, long>
    {
    }
}

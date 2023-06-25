using CommonCore.Entities.Catalogs;
using EssentialCore.Interfaces.Repositories;

namespace ComprasCore.Interfaces.Repositories
{
    public interface IProductoRepository : IRepository<Producto, long>
    {
    }
}

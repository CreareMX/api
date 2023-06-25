using CommonCore.Entities.Catalogs;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ComprasInfraestructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto, long>, IProductoRepository
    {
        public ProductoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

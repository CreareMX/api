using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonInfraestructure.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class ProductoRepository : BaseRepository<Producto, long>, IProductoRepository
    {
        public ProductoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

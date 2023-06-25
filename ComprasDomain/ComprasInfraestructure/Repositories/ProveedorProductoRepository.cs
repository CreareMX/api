using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ComprasInfraestructure.Repositories
{
    public class ProveedorProductoRepository : BaseRepository<ProveedorProducto, long>, IProveedorProductoRepository
    {
        public ProveedorProductoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

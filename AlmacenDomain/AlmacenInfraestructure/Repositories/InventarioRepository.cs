using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class InventarioRepository : BaseRepository<Inventario, long>, IInventarioRepository
    {
        public InventarioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

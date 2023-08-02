using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class DetalleInventarioRepository : BaseRepository<DetalleInventario, long>, IDetalleInventarioRepository
    {
        public DetalleInventarioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

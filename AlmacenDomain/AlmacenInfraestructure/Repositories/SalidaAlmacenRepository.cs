using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class SalidaAlmacenRepository : BaseRepository<SalidaAlmacen, long>, ISalidaAlmacenRepository
    {
        public SalidaAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

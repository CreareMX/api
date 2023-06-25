using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class SalidaAlmacenRepository : BaseRepository<SalidaAlmacen, long>, ISalidaAlmacenRepository
    {
        public SalidaAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

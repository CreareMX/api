using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class EntradaAlmacenRepository : BaseRepository<EntradaAlmacen, long>, IEntradaAlmacenRepository
    {
        public EntradaAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

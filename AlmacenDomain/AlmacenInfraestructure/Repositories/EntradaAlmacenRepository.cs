using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class EntradaAlmacenRepository : BaseRepository<EntradaAlmacen, long>, IEntradaAlmacenRepository
    {
        public EntradaAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

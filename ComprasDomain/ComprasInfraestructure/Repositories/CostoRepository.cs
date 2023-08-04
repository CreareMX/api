using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace ComprasInfraestructure.Repositories
{
    public class CostoRepository : BaseRepository<Costo, long>, ICostoRepository
    {
        public CostoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

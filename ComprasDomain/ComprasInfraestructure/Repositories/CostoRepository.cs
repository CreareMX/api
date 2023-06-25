using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ComprasInfraestructure.Repositories
{
    public class CostoRepository : BaseRepository<Costo, long>, ICostoRepository
    {
        public CostoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

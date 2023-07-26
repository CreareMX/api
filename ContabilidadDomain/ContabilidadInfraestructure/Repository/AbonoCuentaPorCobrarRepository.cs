using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace ContabilidadInfraestructure.Repository
{
    public class AbonoCuentaPorCobrarRepository : BaseRepository<AbonoCuentaPorCobrar, long>, IAbonoCuentaPorCobrarRepository
    {
        public AbonoCuentaPorCobrarRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

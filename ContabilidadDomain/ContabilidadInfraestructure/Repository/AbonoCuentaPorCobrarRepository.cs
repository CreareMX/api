using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ContabilidadInfraestructure.Repository
{
    public class AbonoCuentaPorCobrarRepository : BaseRepository<AbonoCuentaPorCobrar, long>, IAbonoCuentaPorCobrarRepository
    {
        public AbonoCuentaPorCobrarRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

using ContabilidadCore.Entities;
using ContabilidadCore.Interfaces.Reporitories;
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

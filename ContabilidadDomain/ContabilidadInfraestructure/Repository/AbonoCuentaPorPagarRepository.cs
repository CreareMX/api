using ContabilidadCore.Entities;
using ContabilidadCore.Interfaces.Reporitories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ContabilidadInfraestructure.Repository
{
    public class AbonoCuentaPorPagarRepository : BaseRepository<AbonoCuentaPorPagar, long>, IAbonoCuentaPorPagarRepository
    {
        public AbonoCuentaPorPagarRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using CommonCore.DbContexts;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadInfraestructure.Repository
{
    public class CuentaPorCobrarRepository : BaseRepository<CuentaPorCobrar, long>, ICuentaPorCobrarRepository
    {
        public CuentaPorCobrarRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override CuentaPorCobrar GetById(long id) =>
            Context.Set<CuentaPorCobrar>()
                .Include(cc => cc.Cliente)
                .Include(c => c.Cliente.TipoPersona)
                .Include(c => c.Cliente.DatosFiscales)
                .Include(c => c.Cliente.DatosFiscales.EntidadFederativa)
                .Include(cc => cc.Estado)
                .Include(cc => cc.AbonosCuentaPorCobrar)
                .FirstOrDefault(cc => cc.Id == id);
    }
}

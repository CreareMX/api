using CommonCore.Entities.Accounting;
using CommonCore.Interfaces.Repositories.Accounting;
using CommonCore.DbContexts;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadInfraestructure.Repository
{
    public class CuentaPorPagarRepository : BaseRepository<CuentaPorPagar, long>, ICuentaPorPagarRepository
    {
        public CuentaPorPagarRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override CuentaPorPagar GetById(long id) =>
            Context.Set<CuentaPorPagar>()
                .Include(cc => cc.Proveedor)
                .Include(c => c.Proveedor.TipoPersona)
                .Include(c => c.Proveedor.DatosFiscales)
                .Include(c => c.Proveedor.DatosFiscales.EntidadFederativa)
                .Include(cc => cc.Estado)
                .Include(cc => cc.AbonosCuentaPorPagar)
                .FirstOrDefault(cc => cc.Id == id);
    }
}

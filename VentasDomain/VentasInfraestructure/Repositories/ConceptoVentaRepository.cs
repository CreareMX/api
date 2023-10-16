using CommonCore.DbContexts;
using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories.Sales;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace VentasInfraestructure.Repositories
{
    internal class ConceptoVentaRepository : BaseRepository<ConceptoVenta, long>, IConceptoVentaRepository
    {
        public ConceptoVentaRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override IList<ConceptoVenta> GetAll() => Context.Set<ConceptoVenta>().AsNoTracking().Include(p => p.Producto).Include(p => p.Impuestos).Where(a => a.Activo).ToList();

        public override ConceptoVenta GetById(long id) => Context.Set<ConceptoVenta>().AsNoTracking().Include(p => p.Producto).
            Include(p => p.Impuestos).FirstOrDefault(a => a.Id == id && a.Activo);
        public override ConceptoVenta GetByCriteria(IBaseCriteria<ConceptoVenta, long> criteria) => Context.Set<ConceptoVenta>().AsNoTracking().Include(p => p.Producto).
            Include(p => p.Impuestos).Where(criteria.GetExpression()).FirstOrDefault();

        public override IList<ConceptoVenta> GetListByCriteria(IBaseCriteria<ConceptoVenta, long> criteria) => Context.Set<ConceptoVenta>().AsNoTracking().
            Include(p => p.Producto).Include(p => p.Impuestos).Where(criteria.GetExpression()).ToList();
    }
}

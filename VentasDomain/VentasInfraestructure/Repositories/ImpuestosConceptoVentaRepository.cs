using CommonCore.DbContexts;
using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories.Sales;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace VentasInfraestructure.Repositories
{
    internal class ImpuestosConceptoVentaRepository : BaseRepository<ImpuestosConceptoVenta, long>, IImpuestosConceptoVentaRepository
    {
        public ImpuestosConceptoVentaRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override IList<ImpuestosConceptoVenta> GetAll() => Context.Set<ImpuestosConceptoVenta>().AsNoTracking().Where(i => i.Activo).ToList();

        public override ImpuestosConceptoVenta GetById(long id) => Context.Set<ImpuestosConceptoVenta>().AsNoTracking().FirstOrDefault(i => i.Id == id && i.Activo);

        public override ImpuestosConceptoVenta GetByCriteria(IBaseCriteria<ImpuestosConceptoVenta, long> criteria) => Context.Set<ImpuestosConceptoVenta>().
            AsNoTracking().Where(criteria.GetExpression()).FirstOrDefault();

        public override IList<ImpuestosConceptoVenta> GetListByCriteria(IBaseCriteria<ImpuestosConceptoVenta, long> criteria) => Context.Set<ImpuestosConceptoVenta>().
            AsNoTracking().Where(criteria.GetExpression()).ToList();
    }
}

using CommonCore.DbContexts;
using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories.Sales;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace VentasInfraestructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta, long>, IVentaRepository
    {
        public VentaRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override IList<Venta> GetAll() => Context.Set<Venta>().AsNoTracking().Include(p => p.Persona).ThenInclude(p => p.DatosFiscales).
            Include(p => p.Sucursal).Include(p => p.ConceptosVenta).ThenInclude(p => p.Impuestos).Where(a => a.Activo).ToList();

        public override Venta GetById(long id) => Context.Set<Venta>().AsNoTracking().Include(p => p.Persona).ThenInclude(p => p.DatosFiscales).
            Include(p => p.Sucursal).Include(p => p.ConceptosVenta).ThenInclude(p => p.Impuestos).FirstOrDefault(a => a.Id == id && a.Activo);

        public override Venta GetByCriteria(IBaseCriteria<Venta, long> criteria) => Context.Set<Venta>().AsNoTracking().Include(p => p.Persona).ThenInclude(p => p.DatosFiscales).
            Include(p => p.Sucursal).Include(p => p.ConceptosVenta).ThenInclude(p => p.Impuestos).Where(criteria.GetExpression()).FirstOrDefault();

        public override IList<Venta> GetListByCriteria(IBaseCriteria<Venta, long> criteria) => Context.Set<Venta>().AsNoTracking().Include(p => p.Persona).
            ThenInclude(p => p.DatosFiscales).Include(p => p.Sucursal).Include(p => p.ConceptosVenta).ThenInclude(p => p.Impuestos).Where(criteria.GetExpression()).ToList();
    }
}

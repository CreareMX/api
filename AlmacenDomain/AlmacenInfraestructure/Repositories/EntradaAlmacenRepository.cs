using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.DbContexts;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;
using CommonCore.Interfaces.Criterias;

namespace AlmacenInfraestructure.Repositories
{
    public class EntradaAlmacenRepository : BaseRepository<EntradaAlmacen, long>, IEntradaAlmacenRepository
    {
        public EntradaAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override IList<EntradaAlmacen> GetAll() => 
            Context.Set<EntradaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .Where(a => a.Activo)
                .ToList();

        public override EntradaAlmacen GetById(long id) =>
            Context.Set<EntradaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .FirstOrDefault(e => e.Id == id && e.Activo);

        public override EntradaAlmacen GetByCriteria(IBaseCriteria<EntradaAlmacen, long> criteria) =>
            Context.Set<EntradaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .Where(criteria.GetExpression())
                .FirstOrDefault();

        public override IList<EntradaAlmacen> GetListByCriteria(IBaseCriteria<EntradaAlmacen, long> criteria) =>
            Context.Set<EntradaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .Where(criteria.GetExpression())
                .ToList();
    }
}

using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.DbContexts;
using CommonCore.Repositories;
using CommonCore.Interfaces.Criterias;
using Microsoft.EntityFrameworkCore;

namespace AlmacenInfraestructure.Repositories
{
    public class SalidaAlmacenRepository : BaseRepository<SalidaAlmacen, long>, ISalidaAlmacenRepository
    {
        public SalidaAlmacenRepository(SqlServerDbContext context) : base(context) { }
        public override IList<SalidaAlmacen> GetAll() =>
            Context.Set<SalidaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .Where(a => a.Activo)
                .ToList();

        public override SalidaAlmacen GetById(long id) =>
            Context.Set<SalidaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .FirstOrDefault(e => e.Id == id && e.Activo);

        public override SalidaAlmacen GetByCriteria(IBaseCriteria<SalidaAlmacen, long> criteria) =>
            Context.Set<SalidaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .Where(criteria.GetExpression())
                .FirstOrDefault();

        public override IList<SalidaAlmacen> GetListByCriteria(IBaseCriteria<SalidaAlmacen, long> criteria) =>
            Context.Set<SalidaAlmacen>().AsNoTracking()
                .Include(e => e.Almacen)
                .Include(e => e.Producto)
                .Include(e => e.Unidad)
                .Include(e => e.Estado)
                .Include(e => e.Concepto)
                .Where(criteria.GetExpression())
                .ToList();
    }
}

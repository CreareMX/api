using CommonCore.DbContexts;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlmacenInfraestructure.Repositories
{
    public class AlmacenRepository : BaseRepository<Almacen, long>, IAlmacenRepository
    {
        public AlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
        public override IList<Almacen> GetAll() =>
            Context.Set<Almacen>().AsNoTracking()
                .Include(a => a.Sucursal)
                .Include(a => a.TipoAlmacen)
                .Where(a => a.Activo)
                .ToList();

        public override Almacen GetById(long id) =>
            Context.Set<Almacen>().AsNoTracking()
                .Include(a => a.Sucursal)
                .Include(a => a.TipoAlmacen)
                .FirstOrDefault(a => a.Id == id && a.Activo);

        public override Almacen GetByCriteria(IBaseCriteria<Almacen, long> criteria) =>
            Context.Set<Almacen>().AsNoTracking()
                .Include(a => a.Sucursal)
                .Include(a => a.TipoAlmacen)
                .Where(criteria.GetExpression())
                .FirstOrDefault();

        public override IList<Almacen> GetListByCriteria(IBaseCriteria<Almacen, long> criteria) =>
            Context.Set<Almacen>().AsNoTracking()
                .Include(a => a.Sucursal)
                .Include(a => a.TipoAlmacen)
                .Where(criteria.GetExpression())
                .ToList();
    }
}

using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.DbContexts;
using CommonCore.Repositories;
using CommonCore.Interfaces.Criterias;
using Microsoft.EntityFrameworkCore;

namespace AlmacenInfraestructure.Repositories
{
    public class DetalleDetalleInventarioRepository : BaseRepository<DetalleInventario, long>, IDetalleInventarioRepository
    {
        public DetalleDetalleInventarioRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override DetalleInventario GetById(long id) =>
            Context.Set<DetalleInventario>()
                .Include(i => i.Producto)
                .Include(i => i.Unidad)
                .FirstOrDefault(i => i.Id == id && i.Activo);

        public override IList<DetalleInventario> GetListByCriteria(IBaseCriteria<DetalleInventario, long> criteria) =>
            Context.Set<DetalleInventario>()
                .Include(i => i.Producto)
                .Include(i => i.Unidad)
                .Where(criteria.GetExpression())
                .ToList();

        public override DetalleInventario GetByCriteria(IBaseCriteria<DetalleInventario, long> criteria) =>
            Context.Set<DetalleInventario>()
                .Include(i => i.Producto)
                .Include(i => i.Unidad)
                .FirstOrDefault(criteria.GetExpression());

        public override IList<DetalleInventario> GetAll() =>
            Context.Set<DetalleInventario>()
                .Include(i => i.Producto)
                .Include(i => i.Unidad)
                .Where(i => i.Activo)
                .ToList();
    }
}

using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using CommonCore.DbContexts;
using CommonCore.Interfaces.Criterias;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ComprasInfraestructure.Repositories
{
    public class DetalleOrdenCompraRepository : BaseRepository<DetalleOrdenCompra, long>, IDetalleOrdenCompraRepository
    {
        public DetalleOrdenCompraRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override IList<DetalleOrdenCompra> GetAll() =>
            Context.Set<DetalleOrdenCompra>()
            .Include(p => p.Producto)
            .Where(e => e.Activo).ToList();

        public override DetalleOrdenCompra GetById(long id) =>
            Context.Set<DetalleOrdenCompra>()
            .Include(p => p.Producto)
            .FirstOrDefault(e => e.Id == id && e.Activo);

        public override DetalleOrdenCompra GetByCriteria(IBaseCriteria<DetalleOrdenCompra, long> criteria) =>
            Context.Set<DetalleOrdenCompra>()
            .Include(p => p.Producto)
            .FirstOrDefault(criteria.GetExpression());

        public override IList<DetalleOrdenCompra> GetListByCriteria(IBaseCriteria<DetalleOrdenCompra, long> criteria) =>
            Context.Set<DetalleOrdenCompra>()
            .Include(p => p.Producto)
            .Where(criteria.GetExpression()).ToList();
    }
}

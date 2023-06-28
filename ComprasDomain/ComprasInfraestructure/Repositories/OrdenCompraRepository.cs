using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using EssentialCore.DbContexts;
using EssentialCore.Interfaces.Criterias;
using EssentialCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ComprasInfraestructure.Repositories
{
    public class OrdenCompraRepository : BaseRepository<OrdenCompra, long>, IOrdenCompraRepository
    {
        public OrdenCompraRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override IList<OrdenCompra> GetAll() =>
            Context.Set<OrdenCompra>()
            .Include(p => p.Cliente)
            .Include(p => p.Almacen)
            .Include(p => p.Sucursal)
            .Include(p => p.Estado)
            .Include(p => p.EmpleadoCrea)
            .Where(e => e.Activo).ToList();

        public override OrdenCompra GetById(long id) =>
            Context.Set<OrdenCompra>()
            .Include(p => p.Cliente)
            .Include(p => p.Almacen)
            .Include(p => p.Sucursal)
            .Include(p => p.Estado)
            .Include(p => p.EmpleadoCrea)
            .FirstOrDefault(e => e.Id == id && e.Activo);

        public override IList<OrdenCompra> GetListByCriteria(IBaseCriteria<OrdenCompra, long> criteria) =>
            Context.Set<OrdenCompra>()
            .Include(p => p.Cliente)
            .Include(p => p.Almacen)
            .Include(p => p.Sucursal)
            .Include(p => p.Estado)
            .Include(p => p.EmpleadoCrea)
            .Where(criteria.GetExpression()).ToList();
    }
}

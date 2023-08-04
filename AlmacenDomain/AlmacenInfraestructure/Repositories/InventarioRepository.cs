using CommonCore.DbContexts;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlmacenInfraestructure.Repositories
{
    public class InventarioRepository : BaseRepository<Inventario, long>, IInventarioRepository
    {
        public InventarioRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override Inventario GetById(long id) =>
            Context.Set<Inventario>()
                .Include(i => i.Almacen)
                .ThenInclude(a => a.Sucursal)
                .Include(i => i.UsuarioInicio)
                .Include(i => i.UsuarioFin)
                .FirstOrDefault(i => i.Id == id && i.Activo);

        public override IList<Inventario> GetListByCriteria(IBaseCriteria<Inventario, long> criteria) =>
            Context.Set<Inventario>()
                .Include(i => i.Almacen)
                .ThenInclude(a => a.Sucursal)
                .Include(i => i.UsuarioInicio)
                .Include(i => i.UsuarioFin)
                .Where(criteria.GetExpression())
                .ToList();

        public override Inventario GetByCriteria(IBaseCriteria<Inventario, long> criteria) =>
            Context.Set<Inventario>()
                .Include(i => i.Almacen)
                .ThenInclude(a => a.Sucursal)
                .Include(i => i.UsuarioInicio)
                .Include(i => i.UsuarioFin)
                .FirstOrDefault(criteria.GetExpression());

        public override IList<Inventario> GetAll() =>
            Context.Set<Inventario>()
                .Include(i => i.Almacen)
                .ThenInclude(a => a.Sucursal)
                .Include(i => i.UsuarioInicio)
                .Include(i => i.UsuarioFin)
                .Where(i => i.Activo)
                .ToList();
    }
}

using CommonCore.DbContexts;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlmacenInfraestructure.Repositories
{
    public class TransferenciaRepository : BaseRepository<Transferencia, long>, ITransferenciaRepository
    {
        public TransferenciaRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override Transferencia GetById(long id) =>
            Context.Set<Transferencia>()
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Producto)
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Unidad)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Producto)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Unidad)
                .Include(t => t.UsuarioTransfiere)
                .FirstOrDefault(t => t.Id == id && t.Activo);

        public override IList<Transferencia> GetListByCriteria(IBaseCriteria<Transferencia, long> criteria) =>
            Context.Set<Transferencia>()
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Producto)
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Unidad)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Producto)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Unidad)
                .Include(t => t.UsuarioTransfiere)
                .Where(criteria.GetExpression())
                .ToList();

        public override Transferencia GetByCriteria(IBaseCriteria<Transferencia, long> criteria) =>
            Context.Set<Transferencia>()
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Producto)
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Unidad)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Producto)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Unidad)
                .Include(t => t.UsuarioTransfiere)
                .FirstOrDefault(criteria.GetExpression());

        public override IList<Transferencia> GetAll() =>
            Context.Set<Transferencia>()
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Producto)
                .Include(t => t.EntradaAlmacen)
                .ThenInclude(e => e.Unidad)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Producto)
                .Include(t => t.SalidaAlmacen)
                .ThenInclude(s => s.Unidad)
                .Include(t => t.UsuarioTransfiere)
                .Where(t => t.Activo)
                .ToList();
    }
}

using CommonCore.Entities.Catalogs;
using ComprasCore.Interfaces.Repositories;
using CommonCore.DbContexts;
using CommonCore.Interfaces.Criterias;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ComprasInfraestructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto, long>, IProductoRepository
    {
        public ProductoRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override Producto GetById(long id) =>
            Context.Set<Producto>()
                .Include(p => p.Categoria)
                .Include(p => p.Precios)
                .ThenInclude(pr => pr.TipoPrecio)
                .FirstOrDefault(pp => pp.Id == id);

        public override IList<Producto> GetListByCriteria(IBaseCriteria<Producto, long> criteria) =>
            Context.Set<Producto>()
                .Include(p => p.Categoria)
                .Include(p => p.Precios)
                .ThenInclude(pr => pr.TipoPrecio)
                .Where(criteria.GetExpression())
                .ToList();

        public override IList<Producto> GetAll() =>
            Context.Set<Producto>()
                .Include(p => p.Categoria)
                .Include(p => p.Precios)
                .ThenInclude(pr => pr.TipoPrecio)
                .Where(p => p.Activo)
                .ToList();
    }
}

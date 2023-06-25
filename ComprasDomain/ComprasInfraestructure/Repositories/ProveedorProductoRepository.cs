using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ComprasInfraestructure.Repositories
{
    public class ProveedorProductoRepository : BaseRepository<ProveedorProducto, long>, IProveedorProductoRepository
    {
        public ProveedorProductoRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override ProveedorProducto GetById(long id) => 
            Context.Set<ProveedorProducto>()
                .Include(pp => pp.Proveedor)
                .Include(pp => pp.Costo)
                .Include(pp => pp.Producto)
                .ThenInclude(p => p.Categoria)
                .Include(pp => pp.Producto)
                .ThenInclude(p => p.Precios)
                .FirstOrDefault(pp => pp.Id == id);  
    }
}

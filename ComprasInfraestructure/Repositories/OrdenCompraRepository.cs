using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ComprasInfraestructure.Repositories
{
    public class OrdenCompraRepository : BaseRepository<OrdenCompra, long>, IOrdenCompraRepository
    {
        public OrdenCompraRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

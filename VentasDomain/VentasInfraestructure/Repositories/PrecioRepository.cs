using EssentialCore.DbContexts;
using EssentialCore.Repositories;
using VentasCore.Entities;
using VentasCore.Interfaces.Repositories;

namespace VentasInfraestructure.Repositories
{
    public class PrecioRepository : BaseRepository<Precio, long>, IPrecioRepository
    {
        public PrecioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

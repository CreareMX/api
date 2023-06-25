using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class TipoPrecioRepository : BaseRepository<TipoPrecio, long>, ITipoPrecioRepository
    {
        public TipoPrecioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

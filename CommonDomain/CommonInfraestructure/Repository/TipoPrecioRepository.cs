using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class TipoPrecioRepository : BaseRepository<TipoPrecio, long>, ITipoPrecioRepository
    {
        public TipoPrecioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

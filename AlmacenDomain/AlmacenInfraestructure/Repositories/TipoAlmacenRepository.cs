using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class TipoAlmacenRepository : BaseRepository<TipoAlmacen, long>, ITipoAlmacenRepository
    {
        public TipoAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

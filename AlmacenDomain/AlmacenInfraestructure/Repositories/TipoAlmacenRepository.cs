using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class TipoAlmacenRepository : BaseRepository<TipoAlmacen, long>, ITipoAlmacenRepository
    {
        public TipoAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

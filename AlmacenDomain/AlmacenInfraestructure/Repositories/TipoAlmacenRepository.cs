using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
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

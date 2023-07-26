using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class AlmacenRepository : BaseRepository<Almacen, long>, IAlmacenRepository
    {
        public AlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

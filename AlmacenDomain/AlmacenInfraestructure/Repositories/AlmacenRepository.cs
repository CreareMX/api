using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class AlmacenRepository : BaseRepository<Almacen, long>, IAlmacenRepository
    {
        public AlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

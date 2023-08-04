using CommonCore.DbContexts;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repositories
{
    public class PermisoRepository : BaseRepository<Permiso, long>, IPermisoRepository
    {
        public PermisoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

using EssentialCore.DbContexts;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Repositories;

namespace EssentialInfraestructure.Repositories
{
    public class PermisoRepository : BaseRepository<Permiso, long>, IPermisoRepository
    {
        public PermisoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

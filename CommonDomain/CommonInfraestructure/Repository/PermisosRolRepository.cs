using CommonCore.DbContexts;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repositories
{
    public class PermisosRolRepository : BaseRepository<PermisosRol, long>, IPermisosRolRepository
    {
        public PermisosRolRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

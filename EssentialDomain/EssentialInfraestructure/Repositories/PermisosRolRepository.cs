using EssentialCore.DbContexts;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Repositories;

namespace EssentialInfraestructure.Repositories
{
    public class PermisosRolRepository : BaseRepository<PermisosRol, long>, IPermisosRolRepository
    {
        public PermisosRolRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

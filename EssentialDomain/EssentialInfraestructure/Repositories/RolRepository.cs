using EssentialCore.DbContexts;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Repositories;

namespace EssentialInfraestructure.Repositories
{
    public class RolRepository : BaseRepository<Rol, long>, IRolRepository
    {
        public RolRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

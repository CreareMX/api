using CommonCore.DbContexts;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repositories
{
    public class RolRepository : BaseRepository<Rol, long>, IRolRepository
    {
        public RolRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

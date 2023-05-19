using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class SeccionRepository : BaseRepository<Seccion, long>, ISeccionRepository
    {
        public SeccionRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

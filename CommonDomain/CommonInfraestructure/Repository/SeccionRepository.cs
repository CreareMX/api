using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
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

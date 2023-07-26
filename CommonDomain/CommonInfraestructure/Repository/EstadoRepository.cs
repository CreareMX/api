using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class EstadoRepository : BaseRepository<Estado, long>, IEstadoRepository
    {
        public EstadoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

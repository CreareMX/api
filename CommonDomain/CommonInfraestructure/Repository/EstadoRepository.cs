using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class EstadoRepository : BaseRepository<Estado, long>, IEstadoRepository
    {
        public EstadoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

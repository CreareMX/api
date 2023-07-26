using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class UnidadRepository : BaseRepository<Unidad, long>, IUnidadRepository
    {
        public UnidadRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

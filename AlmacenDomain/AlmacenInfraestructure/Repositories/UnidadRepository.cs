using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class UnidadRepository : BaseRepository<Unidad, long>, IUnidadRepository
    {
        public UnidadRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

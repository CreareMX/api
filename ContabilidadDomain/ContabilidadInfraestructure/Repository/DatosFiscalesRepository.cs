using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace ContabilidadInfraestructure.Repository
{
    public class DatosFiscalesRepository : BaseRepository<DatosFiscales, long>, IDatosFiscalesRepository
    {
        public DatosFiscalesRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

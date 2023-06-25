using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ContabilidadInfraestructure.Repository
{
    public class DatosFiscalesRepository : BaseRepository<DatosFiscales, long>, IDatosFiscalesRepository
    {
        public DatosFiscalesRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

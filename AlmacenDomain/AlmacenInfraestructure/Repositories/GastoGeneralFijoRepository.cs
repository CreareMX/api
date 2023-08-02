using CommonCore.DbContexts;
using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class GastoGeneralFijoRepository : BaseRepository<GastoGeneralFijo, long>, IGastoGeneralFijoRepository
    {
        public GastoGeneralFijoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

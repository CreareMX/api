using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class SucursalRepository : BaseRepository<Sucursal, long>, ISucursalRepository
    {
        public SucursalRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

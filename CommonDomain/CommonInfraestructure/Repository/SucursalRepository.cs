using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class SucursalRepository : BaseRepository<Sucursal, long>, ISucursalRepository
    {
        public SucursalRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

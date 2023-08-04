using CommonCore.Entities.Rrhh;
using CommonCore.DbContexts;
using CommonCore.Repositories;
using RRHHCore.Interfaces.Repositories;

namespace RRHHInfraestructure.Repositories
{
    public class PuestoRepository : BaseRepository<Puesto, long>, IPuestoRepository
    {
        public PuestoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

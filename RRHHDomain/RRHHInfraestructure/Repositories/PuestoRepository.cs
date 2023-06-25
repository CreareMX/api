using CommonCore.Entities.Rrhh;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;
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

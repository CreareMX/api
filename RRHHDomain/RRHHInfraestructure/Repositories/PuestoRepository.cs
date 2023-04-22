using EssentialCore.DbContexts;
using EssentialCore.Repositories;
using RRHHCore.Entities;
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

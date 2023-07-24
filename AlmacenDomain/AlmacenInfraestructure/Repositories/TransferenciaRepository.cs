using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class TransferenciaRepository : BaseRepository<Transferencia, long>, ITransferenciaRepository
    {
        public TransferenciaRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

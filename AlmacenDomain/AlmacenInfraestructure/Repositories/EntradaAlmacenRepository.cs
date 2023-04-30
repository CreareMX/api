using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class EntradaAlmacenRepository : BaseRepository<EntradaAlmacen, long>, IEntradaAlmacenRepository
    {
        public EntradaAlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

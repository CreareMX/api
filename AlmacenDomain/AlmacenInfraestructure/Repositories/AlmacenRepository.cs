using AlmacenCore.Entities;
using AlmacenCore.Interfaces.Repositories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class AlmacenRepository : BaseRepository<Almacen, long>, IAlmacenRepository
    {
        public AlmacenRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

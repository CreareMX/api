using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria, long>, ICategoriaRepository
    {
        public CategoriaRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

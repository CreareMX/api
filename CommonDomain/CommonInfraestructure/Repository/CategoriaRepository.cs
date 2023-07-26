using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria, long>, ICategoriaRepository
    {
        public CategoriaRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

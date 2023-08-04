using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class ConceptoRepository : BaseRepository<Concepto, long>, IConceptoRepository
    {
        public ConceptoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

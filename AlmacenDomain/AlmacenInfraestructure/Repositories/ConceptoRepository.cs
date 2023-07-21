using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace AlmacenInfraestructure.Repositories
{
    public class ConceptoRepository : BaseRepository<Concepto, long>, IConceptoRepository
    {
        public ConceptoRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

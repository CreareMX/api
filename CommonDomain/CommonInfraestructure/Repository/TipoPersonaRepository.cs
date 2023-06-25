using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class TipoPersonaRepository : BaseRepository<TipoPersona, long>, ITipoPersonaRepository
    {
        public TipoPersonaRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

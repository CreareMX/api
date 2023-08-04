using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class TipoPersonaRepository : BaseRepository<TipoPersona, long>, ITipoPersonaRepository
    {
        public TipoPersonaRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

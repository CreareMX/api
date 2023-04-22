using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
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

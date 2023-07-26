using CommonCore.DbContexts;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, long>, IUsuarioRepository
    {
        public UsuarioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

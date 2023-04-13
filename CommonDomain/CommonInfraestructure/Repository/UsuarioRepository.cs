using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonInfraestructure.DbContexts;
using EssentialCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario, long>, IUsuarioRepository
    {
        public UsuarioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

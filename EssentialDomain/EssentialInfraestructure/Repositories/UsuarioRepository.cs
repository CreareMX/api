using EssentialCore.DbContexts;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Repositories;

namespace EssentialInfraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, long>, IUsuarioRepository
    {
        public UsuarioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

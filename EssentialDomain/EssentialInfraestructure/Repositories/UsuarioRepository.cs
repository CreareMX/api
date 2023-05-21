using EssentialCore.DbContexts;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Repositories;
using System.Linq.Expressions;

namespace EssentialInfraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, long>, IUsuarioRepository
    {
        public UsuarioRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

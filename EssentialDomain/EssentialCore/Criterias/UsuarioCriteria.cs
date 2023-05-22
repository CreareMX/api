using EssentialCore.Entities;
using EssentialCore.Interfaces.Criterias;

namespace EssentialCore.Criterias
{
    public class UsuarioCriteria : BaseCriteria<Usuario, long>, IUsuarioCriteria
    {
        public IUsuarioCriteria Login(string usuario, string contrasena)
        {
            _expression = x => x.NombreUsuario.ToLower().Trim() == usuario.ToLower().Trim() && x.Contrasena == contrasena && x.Activo;
            return this;
        }

        public IUsuarioCriteria NombreUsuarioExiste(string usuario)
        {
            _expression = x => x.NombreUsuario.ToLower().Trim() == usuario.ToLower().Trim();
            return this;
        }
    }
}

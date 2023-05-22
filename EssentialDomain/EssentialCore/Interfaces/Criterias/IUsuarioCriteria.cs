using EssentialCore.Criterias;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Interfaces.Criterias
{
    public interface IUsuarioCriteria : IBaseCriteria<Usuario, long>
    {
        IUsuarioCriteria Login(string usuario, string contrasena);
        IUsuarioCriteria NombreUsuarioExiste(string usuario);
    }
}
using CommonCore.Criterias;
using CommonCore.Entities;
using CommonCore.Interfaces.Entities;

namespace CommonCore.Interfaces.Criterias
{
    public interface IUsuarioCriteria : IBaseCriteria<Usuario, long>
    {
        IUsuarioCriteria Login(string usuario, string contrasena);
        IUsuarioCriteria NombreUsuarioExiste(string usuario);
    }
}
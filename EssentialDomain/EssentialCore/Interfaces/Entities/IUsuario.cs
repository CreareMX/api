using EssentialCore.Entities;

namespace EssentialCore.Interfaces.Entities
{
    public interface IUsuario : IBaseEntity<long>
    {
        string NombreUsuario { get; set; }
        string Contrasena { get; set; }
        long RolId { get; set; }
    }
}

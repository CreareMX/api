using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Entities
{
    public class Usuario : BaseEntityLongId, IUsuario
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public long RolId { get; set; }
        public Rol Rol { get; set; }
    }
}

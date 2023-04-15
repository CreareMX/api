using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Entities
{
    public class Rol : BaseEntityLongId, IRol
    {
        public string Nombre { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}

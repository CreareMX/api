using CommonCore.Interfaces.Entities;

namespace CommonCore.Entities
{
    public class Rol : BaseEntityLongId, IRol
    {
        public string Nombre { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}

using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Entities
{
    public class Rol : BaseEntityLongId, IRol
    {
        public string Nombre { get; set; }
        public IList<IUsuario> Usuarios { get; set; }
    }
}

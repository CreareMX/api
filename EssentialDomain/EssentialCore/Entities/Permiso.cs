using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Entities
{
    public class Permiso : BaseEntityLongId, IPermiso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}

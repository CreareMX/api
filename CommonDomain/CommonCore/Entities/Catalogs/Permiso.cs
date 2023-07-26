using CommonCore.Interfaces.Entities;

namespace CommonCore.Entities
{
    public class Permiso : BaseEntityLongId, IPermiso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string RutaAcceso { get; set; }
    }
}

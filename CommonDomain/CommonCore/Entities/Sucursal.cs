using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
{
    public class Sucursal : BaseEntityLongId, ISucursal
    {
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
    }
}

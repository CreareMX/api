using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Sucursal : BaseEntityLongId, ISucursal
    {
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
    }
}

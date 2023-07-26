using CommonCore.Interfaces.Entities.Types;
using CommonCore.Entities;

namespace CommonCore.Entities.Types
{
    public class TipoAlmacen : BaseEntityLongId, ITipoAlmacen
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}

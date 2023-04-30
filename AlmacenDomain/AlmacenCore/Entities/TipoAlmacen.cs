using AlmacenCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace AlmacenCore.Entities
{
    public class TipoAlmacen : BaseEntityLongId, ITipoAlmacen
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}

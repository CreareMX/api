using AlmacenCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace AlmacenCore.Entities
{
    public class Almacen : BaseEntityLongId, IAlmacen
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public long IdTipoAlmacen { get; set; }
        public TipoAlmacen TipoAlmacen { get; set; }
    }
}

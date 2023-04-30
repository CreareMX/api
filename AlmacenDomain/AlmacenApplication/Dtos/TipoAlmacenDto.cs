using AlmacenCore.Interfaces.Entities;

namespace AlmacenApplication.Dtos
{
    public class TipoAlmacenDto : ITipoAlmacen
    {
        public long? Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
    }
}

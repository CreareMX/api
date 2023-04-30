using AlmacenCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace AlmacenCore.Entities
{
    public class Unidad : BaseEntityLongId, IUnidad
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public decimal Contenido { get; set; }
    }
}

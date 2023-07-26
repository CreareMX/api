using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Unidad : BaseEntityLongId, IUnidad
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public decimal Contenido { get; set; }
    }
}

using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Concepto : BaseEntityLongId, IConcepto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long IdSeccion { get; set; }
        public Seccion Seccion { get; set; }
    }
}

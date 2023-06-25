using CommonCore.Interfaces.Entities.Catalogs;
using EssentialCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Estado : BaseEntityLongId, IEstado
    {
        public string Nombre { get; set; }
        public long IdSeccion { get; set; }
        public Seccion Seccion { get; set; }
    }
}

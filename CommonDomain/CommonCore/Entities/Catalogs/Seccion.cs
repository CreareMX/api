using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Seccion : BaseEntityLongId, ISeccion
    {
        public string Nombre { get; set; }
    }
}

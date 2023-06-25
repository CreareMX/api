using CommonCore.Interfaces.Entities.Catalogs;
using EssentialCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Seccion : BaseEntityLongId, ISeccion
    {
        public string Nombre { get; set; }
    }
}

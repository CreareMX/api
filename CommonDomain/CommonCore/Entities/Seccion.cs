using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
{
    public class Seccion : BaseEntityLongId, ISeccion
    {
        public string Nombre { get; set; }
    }
}

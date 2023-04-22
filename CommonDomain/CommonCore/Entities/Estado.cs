using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
{
    public class Estado : BaseEntityLongId, IEstado
    {
        public string Nombre { get; set; }
    }
}

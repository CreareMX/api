using CommonCore.Interfaces.Entities.Types;
using EssentialCore.Entities;

namespace CommonCore.Entities.Types
{
    public class TipoPrecio : BaseEntityLongId, ITipoPrecio
    {
        public string Nombre { get; set; }
    }
}

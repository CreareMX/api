using CommonCore.Interfaces.Entities.Types;
using CommonCore.Entities;

namespace CommonCore.Entities.Types
{
    public class TipoPrecio : BaseEntityLongId, ITipoPrecio
    {
        public string Nombre { get; set; }
    }
}

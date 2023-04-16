using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
{
    public class TipoPersona : BaseEntityLongId, ITipoPersona
    {
        public string Nombre { get; set; }
    }
}

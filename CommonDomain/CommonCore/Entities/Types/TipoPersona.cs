using CommonCore.Interfaces.Entities.Types;
using CommonCore.Entities;

namespace CommonCore.Entities.Types
{
    public class TipoPersona : BaseEntityLongId, ITipoPersona
    {
        public string Nombre { get; set; }
        public bool EsPersonaMoral { get; set; }
    }
}

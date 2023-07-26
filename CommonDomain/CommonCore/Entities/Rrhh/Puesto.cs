using CommonCore.Interfaces.Entities.Rrhh;
using CommonCore.Entities;

namespace CommonCore.Entities.Rrhh
{
    public class Puesto : BaseEntityLongId, IPuesto
    {
        public string Nombre { get; set; }
    }
}

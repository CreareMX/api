using EssentialCore.Entities;
using RRHHCore.Interfaces.Entities;

namespace RRHHCore.Entities
{
    public class Puesto : BaseEntityLongId, IPuesto
    {
        public string Nombre { get; set; }
    }
}

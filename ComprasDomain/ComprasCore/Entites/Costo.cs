using ComprasCore.Interfaces.Entites;
using EssentialCore.Entities;

namespace ComprasCore.Entites
{
    public class Costo : BaseEntityLongId, ICosto
    {
        public decimal Monto { get; set; }
    }
}

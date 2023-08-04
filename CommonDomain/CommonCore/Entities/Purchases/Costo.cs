using CommonCore.Interfaces.Entities.Purchases;
using CommonCore.Entities;

namespace CommonCore.Entities.Purchases
{
    public class Costo : BaseEntityLongId, ICosto
    {
        public decimal Monto { get; set; }
    }
}

using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Purchases;
using EssentialCore.Entities;

namespace CommonCore.Entities.Purchases
{
    public class Precio : BaseEntityLongId, IPrecio
    {
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
        public decimal Monto { get; set; }
    }
}

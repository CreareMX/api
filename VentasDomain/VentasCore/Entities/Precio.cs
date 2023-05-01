using CommonCore.Entities;
using EssentialCore.Entities;
using VentasCore.Interfaces.Entities;

namespace VentasCore.Entities
{
    public class Precio : BaseEntityLongId, IPrecio
    {
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
        public decimal Monto { get; set; }
    }
}

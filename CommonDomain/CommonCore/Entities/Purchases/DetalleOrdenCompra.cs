using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Purchases;
using EssentialCore.Entities;

namespace CommonCore.Entities.Purchases
{
    public class DetalleOrdenCompra : BaseEntityLongId, IDetalleOrdenCompra
    {
        public long IdOrdenCompra { get; set; }
        public OrdenCompra OrdenCompra { get; set; }
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
    }
}

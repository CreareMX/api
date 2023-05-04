using CommonCore.Entities;
using ComprasCore.Interfaces.Entites;
using EssentialCore.Entities;

namespace ComprasCore.Entites
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

using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Purchases;

namespace ComprasApplication.Dtos
{
    public class DetalleOrdenCompraDto : IDetalleOrdenCompra
    {
        public long? Id { get; set; }
        public long IdOrdenCompra { get; set; }
        public OrdenCompraDto OrdenCompra { get; set; }
        public long IdProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
    }
}

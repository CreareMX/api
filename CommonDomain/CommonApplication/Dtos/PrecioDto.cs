using CommonCore.Interfaces.Entities.Purchases;

namespace CommonApplication.Dtos
{
    public class PrecioDto : IPrecio
    {
        public long? Id { get; set; }
        public long IdProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public decimal Monto { get; set; }
    }
}

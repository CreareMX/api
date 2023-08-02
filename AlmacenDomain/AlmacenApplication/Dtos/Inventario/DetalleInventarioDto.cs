using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Warehouse;

namespace AlmacenApplication.Dtos.Inventario
{
    public class DetalleInventarioDto : IDetalleInventario
    {
        public long? Id { get; set; }
        public long IdProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public long IdUnidad { get; set; }
        public UnidadDto Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public long IdInventario { get; set; }
    }
}

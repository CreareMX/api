using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Warehouse;

namespace CommonCore.Entities.Warehouse
{
    public class DetalleInventario : BaseEntityLongId, IDetalleInventario
    {
        public long IdInventario { get; set; }
        public Inventario Inventario { get; set; }
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
        public long IdUnidad { get; set; }
        public Unidad Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}

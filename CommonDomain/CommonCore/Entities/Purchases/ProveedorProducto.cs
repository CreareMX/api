using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Purchases;
using EssentialCore.Entities;

namespace CommonCore.Entities.Purchases
{
    public class ProveedorProducto : BaseEntityLongId, IProveedorProducto
    {
        public long IdProveedor { get; set; }
        public Persona Proveedor { get; set; }
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
        public long IdCosto { get; set; }
        public Costo Costo { get; set; }
    }
}

using CommonCore.Entities;
using ComprasCore.Interfaces.Entites;
using ContabilidadCore.Entities;
using EssentialCore.Entities;

namespace ComprasCore.Entites
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

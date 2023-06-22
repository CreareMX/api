using CommonApplication.Dtos;
using ComprasCore.Interfaces.Entites;

namespace ComprasApplication.Dtos
{
    public class ProveedorProductoDto : IProveedorProducto
    {
        public long? Id { get; set; }
        public long IdCosto { get; set; }
        public CostoDto Costo { get; set; }
        public long IdProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public long IdProveedor { get; set; }
        public ProveedorProductoDto ProveedorProducto { get; set; }
    }
}

namespace ComprasCore.Interfaces.Entites
{
    public interface IProveedorProducto
    {
        long IdCosto { get; set; }
        long IdProducto { get; set; }
        long IdProveedor { get; set; }
    }
}
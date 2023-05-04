namespace ComprasCore.Interfaces.Entites
{
    public interface IDetalleOrdenCompra
    {
        decimal Cantidad { get; set; }
        decimal Descuento { get; set; }
        long IdOrdenCompra { get; set; }
        long IdProducto { get; set; }
    }
}
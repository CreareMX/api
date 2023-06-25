namespace CommonCore.Interfaces.Entities.Purchases
{
    public interface IDetalleOrdenCompra
    {
        decimal Cantidad { get; set; }
        decimal Descuento { get; set; }
        long IdOrdenCompra { get; set; }
        long IdProducto { get; set; }
    }
}
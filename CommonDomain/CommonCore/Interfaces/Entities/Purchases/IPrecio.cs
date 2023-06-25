namespace CommonCore.Interfaces.Entities.Purchases
{
    public interface IPrecio
    {
        long IdProducto { get; set; }
        long IdTipoPrecio { get; set; }
        decimal Monto { get; set; }
    }
}
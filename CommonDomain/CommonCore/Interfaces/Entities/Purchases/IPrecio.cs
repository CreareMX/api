namespace CommonCore.Interfaces.Entities.Purchases
{
    public interface IPrecio
    {
        long IdProducto { get; set; }
        decimal Monto { get; set; }
    }
}
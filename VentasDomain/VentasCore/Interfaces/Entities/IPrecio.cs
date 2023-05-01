namespace VentasCore.Interfaces.Entities
{
    public interface IPrecio
    {
        long IdProducto { get; set; }
        decimal Monto { get; set; }
    }
}
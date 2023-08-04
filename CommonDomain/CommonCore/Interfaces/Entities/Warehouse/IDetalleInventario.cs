namespace CommonCore.Interfaces.Entities.Warehouse
{
    public interface IDetalleInventario
    {
        long IdInventario { get; set; }
        long IdProducto { get; set; }
        long IdUnidad { get; set; }
        decimal Cantidad { get; set; }
        DateTime Fecha { get; set; }
    }
}

namespace CommonCore.Interfaces.Entities.Warehouse
{
    public interface IEntradaAlmacen
    {
        decimal Cantidad { get; set; }
        DateTime FechaEntrada { get; set; }
        long IdAlmacen { get; set; }
        long IdProducto { get; set; }
        long IdUnidad { get; set; }
        long IdEstado { get; set; }
        long IdConcepto { get; set; }
    }
}
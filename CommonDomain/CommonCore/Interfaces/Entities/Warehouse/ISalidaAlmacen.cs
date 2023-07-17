namespace CommonCore.Interfaces.Entities.Warehouse
{
    public interface ISalidaAlmacen
    {
        decimal Cantidad { get; set; }
        DateTime FechaSalida { get; set; }
        long IdAlmacen { get; set; }
        long IdProducto { get; set; }
        long IdUnidad { get; set; }
        public long IdEstado { get; set; }
    }
}
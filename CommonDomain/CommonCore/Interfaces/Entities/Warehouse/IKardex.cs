namespace CommonCore.Interfaces.Entities.Warehouse
{
    public interface IKardex
    {
        long IdProducto { get; set; }
		string Producto { get; set; }
		string CodigoProducto { get; set; }
		string CodigoBarras { get; set; }
		long IdUnidad { get; set; }
		string Unidad { get; set; }
		long IdAlmacen { get; set; }
		string Almacen { get; set; }
		decimal? Entrada { get; set; }
		DateTime? FechaEntrada { get; set; }
		decimal? Salida { get; set; }
		DateTime? FechaSalida { get; set; }
        long IdEstado { get; set; }
        string Estado { get; set; }
        long IdConcepto { get; set; }
        string Concepto { get; set; }
    }
}

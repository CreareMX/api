using CommonCore.Interfaces.Entities.Warehouse;

namespace CommonCore.Entities.Warehouse
{
    public class Kardex : BaseEntity<long>, IKardex
    {
        public long IdProducto  { get; set; }
        public string Producto  { get; set; }
        public string CodigoProducto  { get; set; }
        public string CodigoBarras  { get; set; }
        public long IdUnidad  { get; set; }
        public string Unidad  { get; set; }
        public long IdAlmacen  { get; set; }
        public string Almacen  { get; set; }
        public decimal? Entrada  { get; set; }
        public DateTime? FechaEntrada  { get; set; }
        public decimal? Salida  { get; set; }
        public DateTime? FechaSalida  { get; set; }
        public long IdEstado { get; set; }
        public string Estado { get; set; }
        public long IdConcepto { get; set; }
        public string Concepto { get; set; }
    }
}

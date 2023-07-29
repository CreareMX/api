namespace AlmacenApplication.Dtos.Kardex
{
    public class MovimientoKardexDto
    {
        public long IdAlmacen { get; set; }
        public long IdProducto { get; set; }
        public long IdUnidad { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public ElementoKardexDto Estado { get; set; }
        public ElementoKardexDto Concepto { get; set; }
    }
}

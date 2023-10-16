namespace CommonCore.Interfaces.Entities.Sales
{
    public interface IConceptoVenta
    {
        long? Id { get; set; }
        long IdVenta { get; set; }
        long IdProducto { get; set; }
        string Descripcion { get; set; }
        string CodigoInterno { get; set; }
        string UnidadInterna { get; set; }
        string UnidadSAT { get; set; }
        string ProdServCode { get; set; }
        string ObjImpuesto { get; set; }
        double? Cantidad { get; set; }
        double? PrecioUnitario { get; set; }
        double? Descuento { get; set; }
        double? Total { get; set; }
        double? TotalDescuento { get; set; }
        string InformacionAdicional { get; set; }
        long? IdLote { get; set; }
    }
}

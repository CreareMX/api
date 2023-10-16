namespace CommonCore.Interfaces.Entities.Sales
{
    public interface IVenta
    {
        long IdCliente { get; set; }
        long IdSucursal { get; set; }
        string Vendedor { get; set; }
        string Moneda { get; set; }
        decimal? TipoCambio { get; set; }
        string FormaPago { get; set; }
        string Metodopago { get; set; }
        string Serie { get; set; }
        long Folio { get; set; }
        double Subtotal { get; set; }
        double? Descuento { get; set; }
        double Total { get; set; }
        DateTime Fecha { get; set; }
        string Estatus { get; set; }
        long? IdEstatus { get; set; }
    }
}

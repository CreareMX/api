namespace CommonCore.Interfaces.Entities.Accounting
{
    public interface ICuentaPorCobrar
    {
        string Folio { get; set; }
        string Comentarios { get; set; }
        DateTime FechaVencimiento { get; set; }
        DateTime FechaVenta { get; set; }
        long IdCliente { get; set; }
        long IdEstado { get; set; }
        decimal Monto { get; set; }
        decimal Saldo { get; set; }
    }
}
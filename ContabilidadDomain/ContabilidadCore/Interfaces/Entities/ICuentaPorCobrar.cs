namespace ContabilidadCore.Interfaces.Entities
{
    public interface ICuentaPorCobrar
    {
        string? Comentarios { get; set; }
        DateTime FechaVencimiento { get; set; }
        DateTime FechaVenta { get; set; }
        long IdCliente { get; set; }
        long IdEstado { get; set; }
        decimal Monto { get; set; }
        decimal Saldo { get; set; }
    }
}
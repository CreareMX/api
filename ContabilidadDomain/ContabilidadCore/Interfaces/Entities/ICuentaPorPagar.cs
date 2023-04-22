namespace ContabilidadCore.Interfaces.Entities
{
    public interface ICuentaPorPagar
    {
        string Folio { get; set; }
        string Comentarios { get; set; }
        DateTime FechaVencimiento { get; set; }
        long IdProveedor { get; set; }
        long IdEstado { get; set; }
        decimal Monto { get; set; }
        decimal Saldo { get; set; }
    }
}
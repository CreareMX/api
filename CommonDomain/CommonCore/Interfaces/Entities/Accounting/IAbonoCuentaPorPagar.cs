namespace CommonCore.Interfaces.Entities.Accounting
{
    public interface IAbonoCuentaPorPagar
    {
        string Comentarios { get; set; }
        DateTime Fecha { get; set; }
        long IdCuentaPorPagar { get; set; }
        decimal Monto { get; set; }
    }
}
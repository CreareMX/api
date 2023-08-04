namespace CommonCore.Interfaces.Entities.Accounting
{
    public interface IAbonoCuentaPorCobrar
    {
        string Comentarios { get; set; }
        DateTime Fecha { get; set; }
        long IdCuentaPorCobrar { get; set; }
        decimal Monto { get; set; }
    }
}
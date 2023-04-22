namespace ContabilidadCore.Interfaces.Entities
{
    public interface IAbonoCuentaPorPagar
    {
        string Comentarios { get; set; }
        DateTime Fecha { get; set; }
        long IdCuentaPorPagar { get; set; }
        decimal Monto { get; set; }
    }
}
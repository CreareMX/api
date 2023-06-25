using CommonCore.Interfaces.Entities.Accounting;

namespace ContabilidadApplication.Dtos
{
    public class AbonoCuentaPorCobrarDto : IAbonoCuentaPorCobrar
    {
        public long? Id { get; set; }
        public string Comentarios { get; set; }
        public DateTime Fecha { get; set; }
        public long IdCuentaPorCobrar { get; set; }
        public CuentaPorCobrarDto CuentaPorCobrar { get; set; }
        public decimal Monto { get; set; }
    }
}

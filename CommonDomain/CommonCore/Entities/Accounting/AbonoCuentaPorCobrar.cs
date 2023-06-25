using CommonCore.Interfaces.Entities.Accounting;
using EssentialCore.Entities;

namespace CommonCore.Entities.Accounting
{
    public class AbonoCuentaPorCobrar : BaseEntityLongId, IAbonoCuentaPorCobrar
    {
        public long IdCuentaPorCobrar { get; set; }
        public CuentaPorCobrar CuentaPorCobrar { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Comentarios { get; set; }
    }
}

using CommonCore.Interfaces.Entities.Accounting;
using EssentialCore.Entities;

namespace CommonCore.Entities.Accounting
{
    public class AbonoCuentaPorPagar : BaseEntityLongId, IAbonoCuentaPorPagar
    {
        public long IdCuentaPorPagar { get; set; }
        public CuentaPorPagar CuentaPorPagar { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Comentarios { get; set; }
    }
}

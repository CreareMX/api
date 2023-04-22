using CommonCore.Entities;
using ContabilidadCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace ContabilidadCore.Entities
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

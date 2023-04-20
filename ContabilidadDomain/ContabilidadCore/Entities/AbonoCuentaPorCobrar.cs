using CommonCore.Entities;
using ContabilidadCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace ContabilidadCore.Entities
{
    public class AbonoCuentaPorCobrar : BaseEntityLongId, IAbonoCuentaPorCobrar
    {
        public long IdCuentaPorCobrar { get; set; }
        public CuentaPorCobrar CuentaPorCobrar { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string? Comentarios { get; set; }
    }
}

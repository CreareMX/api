using CommonCore.Entities;
using ContabilidadCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace ContabilidadCore.Entities
{
    public class CuentaPorCobrar : BaseEntityLongId, ICuentaPorCobrar
    {
        public long IdCliente { get; set; }
        public string Folio { get; set; }
        public Persona Cliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }
        public string? Comentarios { get; set; }
        public long IdEstado { get; set; }
        public Estado Estado { get; set; }
        public List<AbonoCuentaPorCobrar> AbonosCuentaPorCobrar { get; set; }
    }
}

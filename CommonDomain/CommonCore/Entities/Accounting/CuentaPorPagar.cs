using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Accounting;
using EssentialCore.Entities;

namespace CommonCore.Entities.Accounting
{
    public class CuentaPorPagar : BaseEntityLongId, ICuentaPorPagar
    {
        public long IdProveedor { get; set; }
        public string Folio { get; set; }
        public Persona Proveedor { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }
        public string Comentarios { get; set; }
        public long IdEstado { get; set; }
        public Estado Estado { get; set; }
        public List<AbonoCuentaPorPagar> AbonosCuentaPorPagar { get; set; }
    }
}

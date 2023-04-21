using CommonApplication.Dtos;
using ContabilidadCore.Interfaces.Entities;

namespace ContabilidadApplication.Dtos
{
    public class CuentaPorPagarDto : ICuentaPorPagar
    {
        public long? Id { get; set; }
        public string Folio { get; set; }
        public string? Comentarios { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public long IdProveedor { get; set; }
        public PersonaDto? Proveedor { get; set; }
        public long IdEstado { get; set; }
        public EstadoDto? Estado { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }
        public List<AbonoCuentaPorPagarDto>? Abonos { get; set; }
    }
}

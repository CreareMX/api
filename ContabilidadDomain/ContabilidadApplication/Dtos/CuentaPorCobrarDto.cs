using CommonApplication.Dtos;
using ContabilidadCore.Interfaces.Entities;

namespace ContabilidadApplication.Dtos
{
    public class CuentaPorCobrarDto : ICuentaPorCobrar
    {
        public long? Id { get; set; }
        public string? Comentarios { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaVenta { get; set; }
        public long IdCliente { get; set; }
        public PersonaDto? Cliente { get; set; }
        public long IdEstado { get; set; }
        public EstadoDto? Estado { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }
        public List<AbonoCuentaPorCobrarDto>? Abonos { get; set; }
    }
}

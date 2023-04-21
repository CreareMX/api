using ContabilidadCore.Interfaces.Entities;

namespace ContabilidadApplication.Dtos
{
    public class AbonoCuentaPorPagarDto : IAbonoCuentaPorPagar
    {
        public long? Id { get; set; }
        public string? Comentarios { get; set; }
        public DateTime Fecha { get; set; }
        public long IdCuentaPorPagar { get; set; }
        public CuentaPorPagarDto? CuentaPorPagar { get; set; }
        public decimal Monto { get; set; }
    }
}

using CommonApplication.Dtos;
using ComprasCore.Interfaces.Entites;
using ContabilidadApplication.Dtos;

namespace ComprasApplication.Dtos
{
    public class OrdenCompraDto : IOrdenCompra
    {
        public long? Id { get; set; }
        public long IdCliente { get; set; }
        public PersonaDto Cliente { get; set; }
        public long IdEmpleado { get; set; }
        public PersonaDto Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string FormaEnvio { get; set; }
        public long? IdVenta { get; set; }
        public string Comentarios { get; set; }
        public long IdEstado { get; set; }
        public EstadoDto Estado { get; set; }
    }
}

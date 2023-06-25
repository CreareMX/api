using AlmacenApplication.Dtos;
using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Purchases;
using ContabilidadApplication.Dtos;

namespace ComprasApplication.Dtos
{
    public class OrdenCompraDto : IOrdenCompra
    {
        public long? Id { get; set; }
        public long IdCliente { get; set; }
        public PersonaDto Cliente { get; set; }
        public long IdEmpleadoCrea { get; set; }
        public PersonaDto EmpleadoCrea { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string FormaEnvio { get; set; }
        public long IdAlmacen { get; set; }
        public AlmacenDto Almacen { get; set; }
        public long IdSucursal { get; set; }
        public SucursalDto Sucursal { get; set; }
        public string Comentarios { get; set; }
        public long IdEstado { get; set; }
        public EstadoDto Estado { get; set; }
        public long? IdEmpleadoAutoriza { get; set; }
        public PersonaDto EmpleadoAutoriza { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
    }
}

using CommonCore.Entities;
using ComprasCore.Interfaces.Entites;
using ContabilidadCore.Entities;
using EssentialCore.Entities;

namespace ComprasCore.Entites
{
    public class OrdenCompra : BaseEntityLongId, IOrdenCompra
    {
        public long IdCliente { get; set; }
        public Persona Cliente { get; set; }
        public long IdEmpleado { get; set; }
        public Persona Empleado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string FormaEnvio { get; set; }
        public long IdSucursal { get; set; }
        public Sucursal Sucursal { get; set; }
        public string Comentarios { get; set; }
        public long IdEstado { get; set; }
        public Estado Estado { get; set; }
        public List<DetalleOrdenCompra> Detalles { get; set; }
    }
}

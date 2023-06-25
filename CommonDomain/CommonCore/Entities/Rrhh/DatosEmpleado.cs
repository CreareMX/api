using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Rrhh;
using EssentialCore.Entities;

namespace CommonCore.Entities.Rrhh
{
    public class DatosEmpleado : BaseEntityLongId, IDatosEmpleado
    {
        public long IdEmpleado { get; set; }
        public Persona Empleado { get; set; }
        public long IdPuesto { get; set; }
        public Puesto Puesto { get; set; }
        public long IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
}

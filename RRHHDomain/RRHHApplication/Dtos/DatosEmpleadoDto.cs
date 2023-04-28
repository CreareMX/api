using ContabilidadApplication.Dtos;
using RRHHCore.Interfaces.Entities;

namespace RRHHApplication.Dtos
{
    public class DatosEmpleadoDto : IDatosEmpleado
    {
        public long? Id { get; set; }
        public long IdEmpleado { get; set; }
        public PersonaDto Empleado { get; set; }
        public long IdPuesto { get; set; }
        public PuestoDto Puesto { get; set; }
        public long IdDepartamento { get; set; }
        public DepartamentoDto Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
}

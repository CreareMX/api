using ContabilidadCore.Entities;
using EssentialCore.Entities;
using RRHHCore.Interfaces.Entities;

namespace RRHHCore.Entities
{
    public class Departamento : BaseEntityLongId, IDepartamento
    {
        public string Nombre { get; set; }
        public long IdResponsable { get; set; }
        public Persona Responsable { get; set; }
    }
}

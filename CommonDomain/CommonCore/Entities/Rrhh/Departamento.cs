using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Rrhh;
using CommonCore.Entities;

namespace CommonCore.Entities.Rrhh
{
    public class Departamento : BaseEntityLongId, IDepartamento
    {
        public string Nombre { get; set; }
        public long IdResponsable { get; set; }
        public Persona Responsable { get; set; }
    }
}

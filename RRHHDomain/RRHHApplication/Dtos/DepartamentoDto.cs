using CommonCore.Interfaces.Entities.Rrhh;
using ContabilidadApplication.Dtos;

namespace RRHHApplication.Dtos
{
    public class DepartamentoDto : IDepartamento
    {
        public long? Id { get; set; }
        public string Nombre { get; set; }
        public long IdResponsable { get; set; }
        public PersonaDto Responsable { get; set; }
    }
}

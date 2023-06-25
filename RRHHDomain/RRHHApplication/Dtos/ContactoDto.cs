using CommonCore.Interfaces.Entities.Rrhh;
using ContabilidadApplication.Dtos;

namespace RRHHApplication.Dtos
{
    public class ContactoDto : IContacto
    {
        public long? Id { get; set; }
        public string Email { get; set; }
        public long IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Relacion { get; set; }
        public string Telefono { get; set; }
        public PersonaDto Persona { get; set; }
    }
}

using ContabilidadCore.Entities;
using EssentialCore.Entities;
using RRHHCore.Interfaces.Entities;

namespace RRHHCore.Entities
{
    public class Contacto : BaseEntityLongId, IContacto
    {
        public string Nombre { get; set; }
        public string Relacion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public long IdPersona { get; set; }
        public Persona Persona { get; set; }
    }
}

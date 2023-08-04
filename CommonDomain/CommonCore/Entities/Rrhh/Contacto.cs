using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Rrhh;
using CommonCore.Entities;

namespace CommonCore.Entities.Rrhh
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

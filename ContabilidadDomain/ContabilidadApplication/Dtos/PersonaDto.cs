using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Catalogs;

namespace ContabilidadApplication.Dtos
{
    public class PersonaDto : IPersona
    {
        public long? Id { get; set; }
        public string Email { get; set; }
        public long? IdDatosFiscales { get; set; }
        public long IdTipoPersona { get; set; }
        public string Nombre { get; set; }
        public string SitioWeb { get; set; }
        public string Telefono { get; set; }
        public TipoPersonaDto TipoPersona { get; set; }
        public DatosFiscalesDto DatosFiscales { get; set; }
    }
}

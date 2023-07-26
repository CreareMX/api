using CommonCore.Entities.Types;
using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Persona : BaseEntityLongId, IPersona
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string SitioWeb { get; set; }
        public long IdTipoPersona { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public long? IdDatosFiscales { get; set; }
        public DatosFiscales DatosFiscales { get; set; }
    }
}

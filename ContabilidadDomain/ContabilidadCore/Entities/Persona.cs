using CommonCore.Entities;
using ContabilidadCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace ContabilidadCore.Entities
{
    public class Persona : BaseEntityLongId, IPersona
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string SitioWeb { get; set; }
        public long idTipoPersona { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public long? idDatosFiscales { get; set; }
        public DatosFiscales DatosFiscales { get; set; }
    }
}

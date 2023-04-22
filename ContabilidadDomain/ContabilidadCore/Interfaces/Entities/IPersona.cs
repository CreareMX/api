using CommonCore.Entities;

namespace ContabilidadCore.Interfaces.Entities
{
    public interface IPersona
    {
        string Email { get; set; }
        long? idDatosFiscales { get; set; }
        long idTipoPersona { get; set; }
        string Nombre { get; set; }
        string SitioWeb { get; set; }
        string Telefono { get; set; }
    }
}
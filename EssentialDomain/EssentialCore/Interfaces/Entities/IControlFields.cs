using EssentialCore.Entities;

namespace EssentialCore.Interfaces.Entities
{
    public interface IControlFields
    {
        bool Activo { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime? FechaUltimaActualizacion { get; set; }
        long UsuarioCreaId { get; set; }
        Usuario UsuarioCrea { get; set; }
        long? UsuarioActualizaId { get; set; }
        Usuario UsuarioActualiza { get; set; }
    }
}

namespace EssentialCore.Interfaces.Entities
{
    public interface IControlFields<T> where T : struct
    {
        bool Activo { get; }
        DateTime FehaCreacion { get; }
        DateTime? FechaUltimaActualizacion { get; }
        T UsuarioCreaId { get; }
        IUsuario UsuarioCrea { get; }
        T? UsuarioActualizaId { get; }
        IUsuario UsuarioActualiza { get; }
    }
}

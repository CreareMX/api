namespace EssentialCore.Interfaces.Entities
{
    public interface IRol : IBaseEntity<long>
    {
        string Nombre { get; set; }
        IList<IUsuario> Usuarios { get; set; }
    }
}

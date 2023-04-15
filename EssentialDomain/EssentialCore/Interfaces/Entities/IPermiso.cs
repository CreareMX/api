namespace EssentialCore.Interfaces.Entities
{
    public interface IPermiso : IBaseEntity<long>
    {
        string Nombre { get; set; }
        string Descripcion { get; set; }
        string RutaAcceso { get; set; }
    }
}

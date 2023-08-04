namespace CommonCore.Interfaces.Entities
{
    public interface IUsuario : IBaseEntity<long>
    {
        string NombreUsuario { get; set; }
        string Contrasena { get; set; }
        long RolId { get; set; }
        long IdSucursal { get; set; }
    }
}

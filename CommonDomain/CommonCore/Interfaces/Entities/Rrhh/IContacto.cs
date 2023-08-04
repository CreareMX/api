namespace CommonCore.Interfaces.Entities.Rrhh
{
    public interface IContacto
    {
        string Email { get; set; }
        long IdPersona { get; set; }
        string Nombre { get; set; }
        string Relacion { get; set; }
        string Telefono { get; set; }
    }
}
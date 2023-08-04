namespace CommonCore.Interfaces.Entities.Catalogs
{
    public interface IPersona
    {
        string Email { get; set; }
        long? IdDatosFiscales { get; set; }
        long IdTipoPersona { get; set; }
        string Nombre { get; set; }
        string SitioWeb { get; set; }
        string Telefono { get; set; }
    }
}
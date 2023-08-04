namespace CommonCore.Interfaces.Entities.Catalogs
{
    public interface IUnidad
    {
        string Abreviatura { get; set; }
        decimal Contenido { get; set; }
        string Descripcion { get; set; }
        string Nombre { get; set; }
    }
}
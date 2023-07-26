namespace CommonCore.Interfaces.Entities.Catalogs
{
    public interface IAlmacen
    {
        string Descripcion { get; set; }
        string Nombre { get; set; }
        string Codigo { get; set; }
        long IdTipoAlmacen { get; set; }
        long IdSucursal { get; set; }
    }
}
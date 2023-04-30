namespace AlmacenCore.Interfaces.Entities
{
    public interface IAlmacen
    {
        string Descripcion { get; set; }
        string Nombre { get; set; }
        string Codigo { get; set; }
        long IdTipoAlmacen { get; set; }
    }
}
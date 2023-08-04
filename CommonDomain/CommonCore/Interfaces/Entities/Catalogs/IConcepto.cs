namespace CommonCore.Interfaces.Entities.Catalogs
{
    public interface IConcepto
    {
        string Descripcion { get; set; }
        string Nombre { get; set; }
        long IdSeccion { get; set; }
    }
}
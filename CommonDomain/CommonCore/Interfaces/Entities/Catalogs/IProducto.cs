using EssentialCore.Interfaces.Entities;

namespace CommonCore.Interfaces.Entities.Catalogs
{
    public interface IProducto : IBaseEntity<long>
    {
        string Nombre { get; set; }
        string Descripcion { get; set; }
        string CodigoBarras { get; set; }
        string Codigo { get; set; }
        string NumeroSerie { get; set; }
        long IdCategoria { get; set; }
    }
}

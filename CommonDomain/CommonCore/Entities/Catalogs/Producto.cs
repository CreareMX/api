using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Producto : BaseEntityLongId, IProducto
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        public string NumeroSerie { get; set; }
        public long IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public List<Precio> Precios { get; set; }
    }
}

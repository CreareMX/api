using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
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
    }
}

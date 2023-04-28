using CommonCore.Interfaces.Entities;

namespace CommonApplication.Dtos
{
    public class ProductoDto : IProducto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }
        public string Codigo { get; set; }
        public string NumeroSerie { get; set; }
        public long IdCategoria { get; set; }
        public CategoriaDto Categoria { get; set; }
        public long? Id { get; set; }
    }
}

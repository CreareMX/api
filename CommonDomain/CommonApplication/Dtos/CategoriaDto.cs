using CommonCore.Interfaces.Entities.Catalogs;

namespace CommonApplication.Dtos
{
    public class CategoriaDto : ICategoria 
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
    }
}

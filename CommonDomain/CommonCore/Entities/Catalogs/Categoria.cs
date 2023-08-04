using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Entities;

namespace CommonCore.Entities.Catalogs
{
    public class Categoria : BaseEntityLongId, ICategoria
    {
        public string Nombre { get; set; }
    }
}

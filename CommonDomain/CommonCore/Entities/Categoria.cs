using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
{
    public class Categoria : BaseEntityLongId, ICategoria
    {
        public string Nombre { get; set; }
    }
}

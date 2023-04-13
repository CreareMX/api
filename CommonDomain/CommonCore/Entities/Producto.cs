using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
{
    public class Producto : BaseEntityLongId, IProducto
    {        
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string BarCode { get; set; }
        public string ShortCode { get; set; }
    }
}

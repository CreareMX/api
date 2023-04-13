using CommonCore.Interfaces.Entities;

namespace CommonApplication.Dtos
{
    public class ProductoDto : IProducto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string BarCode { get; set; }
        public string ShortCode { get; set; }
        public long Id { get; set; }
    }
}

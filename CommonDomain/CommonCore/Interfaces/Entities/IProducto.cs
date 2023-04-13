using EssentialCore.Interfaces.Entities;

namespace CommonCore.Interfaces.Entities
{
    public interface IProducto : IBaseEntity<long>
    {
        string Name { get; set; }
        string ShortName { get; set; }
        string BarCode { get; set; }
        string ShortCode { get; set; }
    }
}

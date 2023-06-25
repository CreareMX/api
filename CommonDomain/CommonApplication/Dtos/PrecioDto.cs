using CommonCore.Interfaces.Entities.Purchases;
using Microsoft.Extensions.Logging;

namespace CommonApplication.Dtos
{
    public class PrecioDto : IPrecio
    {
        public long? Id { get; set; }
        public long IdProducto { get; set; }
        public decimal Monto { get; set; }
        public long IdTipoPrecio { get; set; }
        public TipoPrecioDto TipoPrecio { get; set; }
    }
}

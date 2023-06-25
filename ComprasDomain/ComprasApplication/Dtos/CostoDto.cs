using CommonCore.Interfaces.Entities.Purchases;

namespace ComprasApplication.Dtos
{
    public class CostoDto : ICosto
    {
        public long? Id { get; set; }
        public decimal Monto { get; set; }
    }
}

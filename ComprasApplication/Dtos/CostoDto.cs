using ComprasCore.Interfaces.Entites;

namespace ComprasApplication.Dtos
{
    public class CostoDto : ICosto
    {
        public long? Id { get; set; }
        public decimal Monto { get; set; }
    }
}

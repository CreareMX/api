using AlmacenApplication.Dtos;
using CommonCore.Interfaces.Entities.Warehouse;

namespace AlmacenApplication.Dtos
{
    public class TransferenciaDto : ITransferencia
    {
        public long? Id { get; set; }
        public long IdEntradaAlmacen { get; set; }
        public EntradaAlmacenDto EntradaAlmacen { get; set; }
        public long IdSalidaAlmacen { get; set; }
        public SalidaAlmacenDto SalidaAlmacen { get; set; }
        public long IdUsuarioTransfiere { get; set; }
        public DateTime FechaTranferencia { get; set; }
    }
}

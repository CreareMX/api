using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Warehouse;
using EssentialCore.Entities;

namespace CommonCore.Entities.Warehouse
{
    public class Transferencia : BaseEntityLongId, ITransferencia
    {
        public long IdEntradaAlmacen { get; set; }
        public EntradaAlmacen EntradaAlmacen { get; set; }
        public long IdSalidaAlmacen { get; set; }
        public SalidaAlmacen SalidaAlmacen { get; set; }
        public long IdUsuarioTransfiere { get; set; }
        public Persona UsuarioTransfiere { get; set; }
        public DateTime FechaTranferencia { get; set; }
    }
}

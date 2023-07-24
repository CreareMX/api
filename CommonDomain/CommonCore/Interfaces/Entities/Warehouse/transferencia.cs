namespace CommonCore.Interfaces.Entities.Warehouse
{
    public interface ITransferencia
    {
        long IdEntradaAlmacen { get; set; }
        long IdSalidaAlmacen { get; set; }
        long IdUsuarioTransfiere { get; set; }
        DateTime FechaTranferencia { get; set; }
    }
}

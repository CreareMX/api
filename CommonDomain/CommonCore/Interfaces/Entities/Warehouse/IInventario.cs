namespace CommonCore.Interfaces.Entities.Warehouse
{
    public interface IInventario
    {
        long IdAlmacen { get; set; }
        DateTime FechaInicio { get; set; }
        long IdUsuarioInicio { get; set; }
        DateTime? FechaFin { get; set; }
        long? IdUsuarioFin { get; set; }

    }
}

using AlmacenCore.Entities;
using CommonCore.Entities;

namespace AlmacenCore.Interfaces.Entities
{
    public interface IEntradaAlmacen
    {
        decimal Cantidad { get; set; }
        DateTime FechaEntrada { get; set; }
        long IdAlmacen { get; set; }
        long IdProducto { get; set; }
        long IdUnidad { get; set; }
    }
}
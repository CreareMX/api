using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Warehouse;
using CommonCore.Entities;

namespace CommonCore.Entities.Warehouse
{
    public class EntradaAlmacen : BaseEntityLongId, IEntradaAlmacen
    {
        public long IdAlmacen { get; set; }
        public Almacen Almacen { get; set; }
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
        public long IdUnidad { get; set; }
        public Unidad Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaEntrada { get; set; }
        public long IdEstado { get; set; }
        public Estado Estado { get; set; }
        public long IdConcepto { get; set; }
        public Concepto Concepto { get; set; }
    }
}

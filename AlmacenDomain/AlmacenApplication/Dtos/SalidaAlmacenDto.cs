using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Warehouse;

namespace AlmacenApplication.Dtos
{
    public class SalidaAlmacenDto : ISalidaAlmacen
    {
        public long? Id { get; set; }
        public long IdAlmacen { get; set; }
        public AlmacenDto Almacen { get; set; }
        public long IdProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public long IdUnidad { get; set; }
        public UnidadDto Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaSalida { get; set; }
        public long IdEstado { get; set; }
        public EstadoDto Estado { get; set; }
        public long IdConcepto { get; set; }
        public ConceptoDto Concepto { get; set; }
    }
}

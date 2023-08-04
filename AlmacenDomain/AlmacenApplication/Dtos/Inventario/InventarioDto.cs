using CommonApplication.dtos;
using CommonCore.Interfaces.Entities.Warehouse;

namespace AlmacenApplication.Dtos.Inventario
{
    public class InventarioDto : IInventario
    {
        public long? Id { get; set; }
        public long IdAlmacen { get; set; }
        public AlmacenDto Almacen { get; set; }
        public DateTime FechaInicio { get; set; }
        public long IdUsuarioInicio { get; set; }
        public UsuarioDto UsuarioInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public long? IdUsuarioFin { get; set; }
        public UsuarioDto UsuarioFin { get; set; }
        public List<DetalleInventarioDto> Detalles { get; set; }
    }
}

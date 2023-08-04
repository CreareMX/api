using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Warehouse;

namespace CommonCore.Entities.Warehouse
{
    public class Inventario : BaseEntityLongId, IInventario
    {
        public long IdAlmacen { get; set; }
        public Almacen Almacen { get; set; }
        public DateTime FechaInicio { get; set; }
        public long IdUsuarioInicio { get; set; }
        public Usuario UsuarioInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public long? IdUsuarioFin { get; set; }
        public Usuario UsuarioFin { get; set; }
        public List<DetalleInventario> Detalles { get; set; }
    }
}

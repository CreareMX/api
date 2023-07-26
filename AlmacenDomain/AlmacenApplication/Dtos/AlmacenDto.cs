using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Catalogs;

namespace AlmacenApplication.Dtos
{
    public class AlmacenDto : IAlmacen
    {
        public long? Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public long IdTipoAlmacen { get; set; }
        public TipoAlmacenDto TipoAlmacen { get; set; }
        public long IdSucursal { get; set; }
        public SucursalDto Sucursal { get; set; }
    }
}

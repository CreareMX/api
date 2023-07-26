using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities;

namespace CommonCore.Entities
{
    public class Usuario : BaseEntityLongId, IUsuario
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public long RolId { get; set; }
        public Rol Rol { get; set; }
        public long IdSucursal { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}

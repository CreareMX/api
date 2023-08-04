using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities;

namespace CommonApplication.dtos
{
    public class UsuarioDto : IUsuario
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public long? Id { get; set; }
        public long RolId { get; set; }
        public long IdSucursal { get; set; }
        public SucursalDto Sucursal { get; set; }

        public UsuarioDto() { }
        public UsuarioDto(string nombreUsuario, string contrasena, long rolId) {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            RolId = rolId;
        }
    }
}

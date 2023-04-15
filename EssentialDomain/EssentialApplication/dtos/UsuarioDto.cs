using EssentialCore.Entities;
using EssentialCore.Interfaces.Entities;

namespace EssentialApplication.dtos
{
    public class UsuarioDto : IUsuario
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public long? Id { get; set; }
        public long RolId { get; set; }
    }
}

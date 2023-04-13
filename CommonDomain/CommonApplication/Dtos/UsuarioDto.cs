using CommonCore.Interfaces.Entities;

namespace CommonApplication.Dtos
{
    public class UsuarioDto : IUsuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public long Id { get; set; }
    }
}

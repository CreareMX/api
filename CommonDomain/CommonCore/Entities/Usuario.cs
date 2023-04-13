using CommonCore.Interfaces.Entities;
using EssentialCore.Entities;

namespace CommonCore.Entities
{
    public class Usuario : BaseEntityLongId, IUsuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

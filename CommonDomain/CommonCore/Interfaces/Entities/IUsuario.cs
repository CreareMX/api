using EssentialCore.Interfaces.Entities;

namespace CommonCore.Interfaces.Entities
{
    public interface IUsuario : IBaseEntity<long>
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}

using CommonApplication.dtos;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface IUsuarioService : IService<IUsuarioRepository, Usuario, long, UsuarioDto>
    {
        UsuarioDto Login(string usuario, string contrasena);
    }
}

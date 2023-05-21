using EssentialApplication.dtos;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace EssentialApplication.Interfaces
{
    public interface IUsuarioService : IService<IUsuarioRepository, Usuario, long, UsuarioDto>
    {
        UsuarioDto Login(string usuario, string contrasena);
    }
}

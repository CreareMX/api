using AutoMapper;
using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Criterias;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace EssentialApplication.Services
{
    public class UsuarioService : BaseService<IUsuarioRepository, Usuario, long, UsuarioDto>, IUsuarioService
    {
        private readonly IUsuarioCriteria _usuarioCriteria;
        public UsuarioService(IUsuarioRepository repository, IUsuarioCriteria usuarioCriteria, IMapper mapper) : base(repository, mapper)
        {
            _usuarioCriteria = usuarioCriteria;
        }

        public UsuarioDto Login(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new Exception("No se ha indicado un nombre de usuario.");

            if (string.IsNullOrWhiteSpace(contrasena))
                throw new Exception("La contraseña no puede estar vacía.");
                        
            var entity = Repository.GetByCriteria(_usuarioCriteria.Login(usuario, contrasena));
            return entity == null ? throw new Exception("Usuario no autorizado, por favor verifique su nombre de usuario o contraseña.") : Mapper.Map<UsuarioDto>(entity);
        }
    }
}

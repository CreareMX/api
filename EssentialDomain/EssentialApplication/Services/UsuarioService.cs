using AutoMapper;
using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Criterias;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Services;
using System.Security.Cryptography;
using System.Text;

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
            EjecutaValidaciones(new UsuarioDto(usuario, contrasena, 0), true, true, false);

            var entity = Repository.GetByCriteria(_usuarioCriteria.Login(usuario, EncriptarContrasena(contrasena)));
            return entity == null ? throw new Exception("Usuario no autorizado, por favor verifique su nombre de usuario o contraseña.") : Mapper.Map<UsuarioDto>(entity);
        }

        public override UsuarioDto Create(UsuarioDto dto, long idUser)
        {
            EjecutaValidaciones(dto);
            dto.Contrasena = EncriptarContrasena(dto.Contrasena);

            return base.Create(dto, idUser);
        }

        public override void Update(UsuarioDto dto, long idUser)
        {
            EjecutaValidaciones(dto);
            dto.Contrasena = EncriptarContrasena(dto.Contrasena);

            base.Update(dto, idUser);
        }

        private void EjecutaValidaciones(UsuarioDto dto, bool validaNombreUsuario = true, bool validaContrasena = true, bool validaExistencia = true)
        {
            if (validaNombreUsuario && string.IsNullOrWhiteSpace(dto.NombreUsuario))
                throw new Exception("No se puede crear un nombre de usuario vacío");

            if (validaContrasena && string.IsNullOrWhiteSpace(dto.Contrasena))
                throw new Exception("No se puede crear una contraseña vacía");

            if (validaExistencia)
            {
                var usuarioActual = Repository.GetById(dto.Id.Value);
                var usuarioExiste = Repository.GetByCriteria(_usuarioCriteria.NombreUsuarioExiste(dto.NombreUsuario));
                if (usuarioExiste != null && !usuarioActual.NombreUsuario.Equals(usuarioExiste.NombreUsuario, StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception($"Ya existe un usuario dado de alta como '{dto.NombreUsuario}'.");
            }
        }

        private static string EncriptarContrasena(string contrasena)
        {
            using var encripter = SHA256.Create();
            var hashLogin = encripter.ComputeHash(Encoding.ASCII.GetBytes(contrasena));
            var stringHash = string.Empty;
            for (int i = 0; i < hashLogin.Length; i++)
            {
                stringHash += ($"{hashLogin[i]:X2}");
                if ((i % 4) == 3) stringHash += " ";
            }

            return stringHash.Trim();
        }
    }
}

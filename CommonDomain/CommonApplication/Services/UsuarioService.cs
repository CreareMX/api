using AutoMapper;
using CommonApplication.dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories;
using CommonCore.Services;
using System.Security.Cryptography;
using System.Text;

namespace CommonApplication.Services
{
    public class UsuarioService : BaseService<IUsuarioRepository, Usuario, long, UsuarioDto>, IUsuarioService
    {
        private readonly IUsuarioCriteria _usuarioCriteria;
        private readonly IRolService _rolService;
        private readonly ISucursalService _sucursalService;
        public UsuarioService(IUsuarioRepository repository, IUsuarioCriteria usuarioCriteria, IRolService rolService, 
            ISucursalService sucursalService, IMapper mapper) : base(repository, mapper)
        {
            _usuarioCriteria = usuarioCriteria;
            _rolService = rolService;
            _sucursalService = sucursalService;
        }

        public UsuarioDto Login(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario))
                throw new Exception("Nombre de usuario vacío");

            if (string.IsNullOrWhiteSpace(contrasena))
                throw new Exception("Contraseña vacía");

            var entity = Repository.GetByCriteria(_usuarioCriteria.Login(usuario, EncriptarContrasena(contrasena)));
            Repository.ClearTracker(true);

            return entity == null ? throw new Exception("Usuario no autorizado, por favor verifique su nombre de usuario o contraseña.") : Mapper.Map<UsuarioDto>(entity);
        }

        public override UsuarioDto Create(UsuarioDto dto, long idUser)
        {
            Validaciones(dto);
            dto.Contrasena = EncriptarContrasena(dto.Contrasena);

            return base.Create(dto, idUser);
        }

        public override void Update(UsuarioDto dto, long idUser)
        {
            Validaciones(dto);
            dto.Contrasena = EncriptarContrasena(dto.Contrasena);

            base.Update(dto, idUser);
        }

        protected override void Validaciones(UsuarioDto dto)
        { 
            if (string.IsNullOrWhiteSpace(dto.NombreUsuario))
                throw new Exception("No se puede crear un nombre de usuario vacío");

            if (string.IsNullOrWhiteSpace(dto.Contrasena))
                throw new Exception("No se puede crear una contraseña vacía");

            var rol = _rolService.GetById(dto.RolId) ?? throw new Exception($"No existe un rol con ID: {dto.RolId}.");
            var sucursal = _sucursalService.GetById(dto.IdSucursal) ?? throw new Exception($"No existe una sucursal con ID: {dto.IdSucursal}.");

            dto.RolId = rol.Id.Value;
            dto.IdSucursal = sucursal.Id.Value;

            var usuarioActual = Repository.GetById(dto.Id.Value);
            var usuarioExiste = Repository.GetByCriteria(_usuarioCriteria.NombreUsuarioExiste(dto.NombreUsuario));
            Repository.ClearTracker(true);

            if (usuarioExiste != null && !usuarioActual.NombreUsuario.Equals(usuarioExiste.NombreUsuario, StringComparison.InvariantCultureIgnoreCase))
                throw new Exception($"Ya existe un usuario dado de alta como '{dto.NombreUsuario}'.");
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

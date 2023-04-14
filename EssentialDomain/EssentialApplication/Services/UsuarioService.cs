using AutoMapper;
using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using EssentialCore.Entities;
using EssentialCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace EssentialApplication.Services
{
    public class UsuarioService : BaseService<IUsuarioRepository, Usuario, long, UsuarioDto>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class UsuarioService : BaseService<IUsuarioRepository, Usuario, long, UsuarioDto>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class EstadoService : BaseService<IEstadoRepository, Estado, long, EstadoDto>, IEstadoService
    {
        public EstadoService(IEstadoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

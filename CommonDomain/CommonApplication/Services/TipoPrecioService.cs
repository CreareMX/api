using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class TipoPrecioService : BaseService<ITipoPrecioRepository, TipoPrecio, long, TipoPrecioDto>, ITipoPrecioService
    {
        public TipoPrecioService(ITipoPrecioRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

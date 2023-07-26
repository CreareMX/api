using AutoMapper;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using CommonCore.Services;

namespace ComprasApplication.Services
{
    public class CostoService : BaseService<ICostoRepository, Costo, long, CostoDto>, ICostoService
    {
        public CostoService(ICostoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

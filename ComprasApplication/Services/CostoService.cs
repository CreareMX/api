using AutoMapper;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace ComprasApplication.Services
{
    public class CostoService : BaseService<ICostoRepository, Costo, long, CostoDto>, ICostoService
    {
        public CostoService(ICostoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

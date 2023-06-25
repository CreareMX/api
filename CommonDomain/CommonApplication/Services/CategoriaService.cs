using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class CategoriaService : BaseService<ICategoriaRepository, Categoria, long, CategoriaDto>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

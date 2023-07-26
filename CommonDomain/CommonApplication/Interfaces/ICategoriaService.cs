using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Interfaces.Service;

namespace CommonApplication.Interfaces
{
    public interface ICategoriaService : IService<ICategoriaRepository, Categoria, long, CategoriaDto>
    {
    }
}

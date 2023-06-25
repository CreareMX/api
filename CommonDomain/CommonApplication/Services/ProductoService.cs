using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class ProductoService : BaseService<IProductoRepository, Producto, long, ProductoDto>, IProductoService
    {
        public ProductoService(IProductoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

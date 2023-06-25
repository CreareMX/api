using AutoMapper;
using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using EssentialCore.Services;

namespace ComprasApplication.Services
{
    public class ProveedorProductoService : BaseService<IProveedorProductoRepository, ProveedorProducto, long, ProveedorProductoDto>, IProveedorProductoService
    {
        public ProveedorProductoService(IProveedorProductoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

using AutoMapper;
using ComprasApplication.Dtos;
using ComprasApplication.Interfaces;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
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

using ComprasApplication.Dtos;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace ComprasApplication.Interfaces
{
    public interface IProveedorProductoService : IService<IProveedorProductoRepository, ProveedorProducto, long, ProveedorProductoDto>
    {
    }
}

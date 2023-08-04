using AlmacenApplication.Dtos.Inventario;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Interfaces.Service;

namespace DetalleInventarioApplication.Interfaces
{
    public interface IDetalleInventarioService : IService<IDetalleInventarioRepository, DetalleInventario, long, DetalleInventarioDto>
    {
    }
}

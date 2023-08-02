using AlmacenApplication.Dtos.Inventario;
using AlmacenApplication.Dtos.Kardex;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Interfaces.Service;

namespace InventarioApplication.Interfaces
{
    public interface IInventarioService : IService<IInventarioRepository, Inventario, long, InventarioDto>
    {
        KardexDto ObtenerKardex(DateTime fecha, long idAlmacen);
        KardexDto ObtenerBajoStock(DateTime fecha, long idAlmacen);
        KardexDto ObtenerDiferencias(long idInventario);
    }
}

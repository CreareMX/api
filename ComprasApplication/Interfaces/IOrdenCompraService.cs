using ComprasApplication.Dtos;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
using EssentialCore.Interfaces.Service;

namespace ComprasApplication.Interfaces
{
    public interface IOrdenCompraService : IService<IOrdenCompraRepository, OrdenCompra, long, OrdenCompraDto>
    {
        IList<OrdenCompraDto> OrdenesPorAlmacen(long idAlmacen);
        IList<OrdenCompraDto> RequisicionesPorAlmacen(long idAlmacen, long idSucursal);
    }
}

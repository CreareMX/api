using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using CommonCore.Interfaces.Service;

namespace ComprasApplication.Interfaces
{
    public interface IOrdenCompraService : IService<IOrdenCompraRepository, OrdenCompra, long, OrdenCompraDto>
    {
        IList<OrdenCompraDto> OrdenesPorAlmacen(long idAlmacen);
        IList<OrdenCompraDto> RequisicionesPorSucursal(long idSucursal);
        void UpdateStatus(long idOrdenCompra, long idEstado, long idUsuarioCancela);
    }
}

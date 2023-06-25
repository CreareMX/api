using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using EssentialCore.Interfaces.Service;

namespace ComprasApplication.Interfaces
{
    public interface IOrdenCompraService : IService<IOrdenCompraRepository, OrdenCompra, long, OrdenCompraDto>
    {
        IList<OrdenCompraDto> OrdenesPorAlmacen(long idAlmacen);
        IList<OrdenCompraDto> RequisicionesPorSucursal(long idSucursal);
        void Autorizar(long idOrdenCompra, long idUsuarioAutoriza);
        void Cancelar(long idOrdenCompra, long idUsuarioCancela);
    }
}

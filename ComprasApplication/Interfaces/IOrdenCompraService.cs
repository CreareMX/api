using ComprasApplication.Dtos;
using ComprasCore.Entites;
using ComprasCore.Interfaces.Repositories;
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

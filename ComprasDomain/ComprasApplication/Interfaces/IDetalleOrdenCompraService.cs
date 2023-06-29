using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Repositories.Purchases;
using ComprasApplication.Dtos;
using EssentialCore.Interfaces.Service;

namespace ComprasApplication.Interfaces
{
    public interface IDetalleOrdenCompraService : IService<IDetalleOrdenCompraRepository, DetalleOrdenCompra, long, DetalleOrdenCompraDto>
    {
        List<DetalleOrdenCompraDto> GetByOrdenCompra(long idOrdenCompra);
    }
}

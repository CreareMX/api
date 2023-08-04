using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Purchases
{
    public interface IDetalleOrdenCompraCriteria : IBaseCriteria<DetalleOrdenCompra, long>
    {
        IDetalleOrdenCompraCriteria PorOrdenCompra(long idOrdenCompra);
    }
}

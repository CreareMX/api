using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Purchases
{
    public interface IOrdenCompraCriteria : IBaseCriteria<OrdenCompra, long>
    {
        IOrdenCompraCriteria PorAlmacen(long idAlmacen);
        IOrdenCompraCriteria PorSucursal(long idSucursal);
    }
}

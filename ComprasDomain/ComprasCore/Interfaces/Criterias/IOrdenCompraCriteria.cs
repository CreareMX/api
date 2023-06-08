using ComprasCore.Entites;
using EssentialCore.Interfaces.Criterias;

namespace ComprasCore.Interfaces.Criterias
{
    public interface IOrdenCompraCriteria : IBaseCriteria<OrdenCompra, long>
    {
        IOrdenCompraCriteria PorAlmacen(long idAlmacen);
        IOrdenCompraCriteria PorSucursal(long idSucursal);
    }
}

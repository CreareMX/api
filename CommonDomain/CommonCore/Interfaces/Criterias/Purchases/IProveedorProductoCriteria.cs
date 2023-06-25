using CommonCore.Entities.Purchases;
using EssentialCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Purchases
{
    public interface IProveedorProductoCriteria : IBaseCriteria<ProveedorProducto, long>
    {
        IProveedorProductoCriteria PorProducto(long idProducto);
        IProveedorProductoCriteria PorProveedor(long idProveedor);
    }
}

using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias.Purchases;
using CommonCore.Criterias;

namespace CommonCore.Criterias.Purchases
{
    public class ProveedorProductoCriteria : BaseCriteria<ProveedorProducto, long>, IProveedorProductoCriteria
    {
        public IProveedorProductoCriteria PorProducto(long idProducto)
        {
            _expression = x => x.IdProducto == idProducto && x.Activo;
            return this;
        }

        public IProveedorProductoCriteria PorProveedor(long idProveedor)
        {
            _expression = x => x.IdProveedor == idProveedor && x.Activo;
            return this;
        }
    }
}

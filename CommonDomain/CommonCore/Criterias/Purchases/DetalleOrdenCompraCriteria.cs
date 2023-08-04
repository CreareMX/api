using CommonCore.Entities.Purchases;
using CommonCore.Interfaces.Criterias.Purchases;
using CommonCore.Criterias;
using CommonCore.Interfaces.Criterias;
using System.Linq.Expressions;

namespace CommonCore.Criterias.Purchases
{
    public class DetalleOrdenCompraCriteria : BaseCriteria<DetalleOrdenCompra, long>, IDetalleOrdenCompraCriteria
    {
        public IDetalleOrdenCompraCriteria PorOrdenCompra(long idOrdenCompra)
        {
            _expression = x => x.IdOrdenCompra == idOrdenCompra && x.Activo;
            return this;
        }
    }
}

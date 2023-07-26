using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Criterias.Warehouse;
using CommonCore.Criterias;

namespace CommonCore.Criterias.Warehouse
{
    public class EntradaAlmacenCriteria : BaseCriteria<EntradaAlmacen, long>, IEntradaAlmacenCriteria
    {
        public IEntradaAlmacenCriteria PorAlmacen(long idAlmacen)
        {
            _expression = x => x.IdAlmacen == idAlmacen && x.Activo;
            return this;
        }
    }
}

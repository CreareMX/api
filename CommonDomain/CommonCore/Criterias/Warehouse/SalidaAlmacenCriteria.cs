using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Criterias.Warehouse;
using CommonCore.Criterias;

namespace CommonCore.Criterias.Warehouse
{
    public class SalidaAlmacenCriteria : BaseCriteria<SalidaAlmacen, long>, ISalidaAlmacenCriteria
    {
        public ISalidaAlmacenCriteria PorAlmacen(long idAlmacen)
        {
            _expression = x => x.IdAlmacen == idAlmacen && x.Activo;
            return this;
        }
    }
}

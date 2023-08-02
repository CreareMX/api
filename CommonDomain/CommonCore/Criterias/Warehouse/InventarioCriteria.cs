using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Criterias.Warehouse;

namespace CommonCore.Criterias.Warehouse
{
    public class InventarioCriteria : BaseCriteria<Inventario, long>, IInventarioCriteria
    {
        public IInventarioCriteria PorFechaAlmacen(DateTime fecha, long idAlmacen)
        {
            _expression = x => x.IdAlmacen == idAlmacen && x.FechaInicio.Date == fecha.Date && x.Activo;
            return this;
        }
    }
}

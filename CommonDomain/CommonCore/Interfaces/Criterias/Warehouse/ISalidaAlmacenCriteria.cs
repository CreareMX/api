using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Warehouse
{
    public interface ISalidaAlmacenCriteria : IBaseCriteria<SalidaAlmacen, long>
    {
        ISalidaAlmacenCriteria PorAlmacen(long idAlmacen);
    }
}

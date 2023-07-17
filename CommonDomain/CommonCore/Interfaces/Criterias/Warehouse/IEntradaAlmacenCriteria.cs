using CommonCore.Entities.Warehouse;
using EssentialCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Warehouse
{
    public interface IEntradaAlmacenCriteria : IBaseCriteria<EntradaAlmacen, long>
    {
        IEntradaAlmacenCriteria PorAlmacen(long idAlmacen);
    }
}

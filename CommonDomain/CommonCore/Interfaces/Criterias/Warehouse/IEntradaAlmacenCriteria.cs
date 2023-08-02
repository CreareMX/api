using CommonCore.Entities.Warehouse;

namespace CommonCore.Interfaces.Criterias.Warehouse
{
    public interface IEntradaAlmacenCriteria : IBaseCriteria<EntradaAlmacen, long>
    {
        IEntradaAlmacenCriteria PorAlmacen(long idAlmacen);
    }
}

using CommonCore.Entities.Warehouse;

namespace CommonCore.Interfaces.Criterias.Warehouse
{
    public interface IInventarioCriteria : IBaseCriteria<Inventario, long>
    {
        IInventarioCriteria PorFechaAlmacen(DateTime fecha, long idAlmacen);
    }
}

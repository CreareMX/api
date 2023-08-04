using CommonCore.Entities.Warehouse;

namespace CommonCore.Interfaces.Repositories.Warehouse
{
    public interface IKardexRepository : IRepository<Kardex, long>
    {
        List<Kardex> GetKardex(long idAlmacen, DateTime fechaLimite, long idEstadoEntrada, long idEstadoSalida);
    }
}

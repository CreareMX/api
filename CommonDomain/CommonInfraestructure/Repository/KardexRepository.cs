using CommonCore.DbContexts;
using CommonCore.Entities.Warehouse;
using CommonCore.Interfaces.Repositories.Warehouse;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CommonInfraestructure.Repositories
{
    public class KardexRepository : BaseRepository<Kardex, long>, IKardexRepository
    {
        public KardexRepository(SqlServerDbContext context) : base(context)
        {
        }

        public List<Kardex> GetKardex(long idAlmacen, DateTime fechaLimite, long idEstadoEntrada, long idEstadoSalida) => 
            Context.Set<Kardex>().AsNoTracking()
                    .Where(x => x.IdAlmacen == idAlmacen && (
                                (x.FechaEntrada.HasValue && x.FechaEntrada.Value.Date <= fechaLimite.Date) || 
                                (x.FechaSalida.HasValue && x.FechaSalida.Value.Date <= fechaLimite.Date) &&
                                (x.IdEstado == idEstadoEntrada || x.IdEstado == idEstadoSalida)
                            )).ToList();
    }
}

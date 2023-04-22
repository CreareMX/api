using ContabilidadCore.Entities;
using ContabilidadCore.Interfaces.Reporitories;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;

namespace ContabilidadInfraestructure.Repository
{
    public class DatosFiscalesRepository : BaseRepository<DatosFiscales, long>, IDatosFiscalesRepository
    {
        public DatosFiscalesRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

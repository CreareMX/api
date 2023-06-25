using CommonCore.Entities.Rrhh;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;
using Microsoft.EntityFrameworkCore;
using RRHHCore.Interfaces.Repositories;

namespace RRHHInfraestructure.Repositories
{
    public class DepartamentoRepository : BaseRepository<Departamento, long>, IDepartamentoRepository
    {
        public DepartamentoRepository(SqlServerDbContext context) : base(context)
        {
        }
        public override Departamento GetById(long id) => Context.Set<Departamento>()
                                                            .Include(p => p.Responsable)
                                                            .FirstOrDefault(p => p.Id == id);
    }
}

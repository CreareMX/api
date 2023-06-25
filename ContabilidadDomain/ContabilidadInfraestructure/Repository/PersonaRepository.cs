using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.DbContexts;
using EssentialCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadInfraestructure.Repository
{
    public class PersonaRepository : BaseRepository<Persona, long>, IPersonaRepository
    {
        public PersonaRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override Persona GetById(long id) => Context.Set<Persona>()
                                                            .Include(p => p.TipoPersona)
                                                            .Include(p => p.DatosFiscales)
                                                            .ThenInclude(df => df.EntidadFederativa)
                                                            .FirstOrDefault(p => p.Id == id);
    }
}

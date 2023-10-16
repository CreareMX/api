using CommonCore.DbContexts;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadInfraestructure.Repository
{
    public class PersonaRepository : BaseRepository<Persona, long>, IPersonaRepository
    {
        public PersonaRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override Persona GetById(long id) => Context.Set<Persona>().Include(p => p.TipoPersona).
            Include(p => p.DatosFiscales).ThenInclude(df => df.EntidadFederativa).FirstOrDefault(p => p.Id == id && p.Activo);

        public override IList<Persona> GetAll() => Context.Set<Persona>().Include(p => p.TipoPersona).
            Include(p => p.DatosFiscales).ThenInclude(df => df.EntidadFederativa).Where(p => p.Activo).ToList();

        public override IList<Persona> GetListByCriteria(IBaseCriteria<Persona, long> criteria) => Context.Set<Persona>().Include(p => p.TipoPersona).
            Include(p => p.DatosFiscales).ThenInclude(df => df.EntidadFederativa).Where(criteria.GetExpression()).ToList();
    }
}

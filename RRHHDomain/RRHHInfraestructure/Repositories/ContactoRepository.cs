using CommonCore.Entities.Rrhh;
using CommonCore.DbContexts;
using CommonCore.Repositories;
using Microsoft.EntityFrameworkCore;
using RRHHCore.Interfaces.Repositories;

namespace RRHHInfraestructure.Repositories
{
    public class ContactoRepository : BaseRepository<Contacto, long>, IContactoRepository
    {
        public ContactoRepository(SqlServerDbContext context) : base(context)
        {
        }

        public override Contacto GetById(long id) => Context.Set<Contacto>()
                                                            .Include(p => p.Persona)
                                                            .FirstOrDefault(p => p.Id == id);
    }
}

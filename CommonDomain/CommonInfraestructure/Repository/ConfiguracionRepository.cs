using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.DbContexts;
using CommonCore.Repositories;

namespace CommonInfraestructure.Repository
{
    public class ConfiguracionRepository : BaseRepository<Configuracion, long>, IConfiguracionRepository
    {
        public ConfiguracionRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}

using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Services;

namespace CommonApplication.Services
{
    public class ConfiguracionService : BaseService<IConfiguracionRepository, Configuracion, long, ConfiguracionDto>, IConfiguracionService
    {
        readonly IConfiguracionCriteria _ConfiguracionCriteria;
        public ConfiguracionService(IConfiguracionRepository repository, IMapper mapper, IConfiguracionCriteria ConfiguracionCriteria) : base(repository, mapper)
        {
            _ConfiguracionCriteria = ConfiguracionCriteria;
        }

        public ConfiguracionDto PorNombre(string seccion)
        {
            var result = Repository.GetByCriteria(_ConfiguracionCriteria.PorNombre(seccion));
            return Mapper.Map<ConfiguracionDto>(result);
        }
    }
}

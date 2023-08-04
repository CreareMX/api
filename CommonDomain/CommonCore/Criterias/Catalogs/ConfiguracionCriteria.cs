using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias.Catalogs;

namespace CommonCore.Criterias.Catalogs
{
    public class ConfiguracionCriteria : BaseCriteria<Configuracion, long>, IConfiguracionCriteria
    {
        public IConfiguracionCriteria PorNombre(string nombre)
        {
            _expression = x => x.Nombre.ToUpper().Trim() == nombre.ToUpper().Trim();
            return this;
        }
    }
}

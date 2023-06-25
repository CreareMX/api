using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias.Catalogs;
using EssentialCore.Criterias;

namespace CommonCore.Criterias.Catalogs
{
    public class EstadoCriteria : BaseCriteria<Estado, long>, IEstadoCriteria
    {
        public IEstadoCriteria PorSeccion(string seccion)
        {
            _expression = x => x.Seccion.Nombre.ToUpper().Trim() == seccion.ToUpper().Trim();
            return this;
        }
    }
}

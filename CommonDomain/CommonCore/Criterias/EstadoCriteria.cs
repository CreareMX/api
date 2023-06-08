using CommonCore.Entities;
using CommonCore.Interfaces.Criterias;
using EssentialCore.Criterias;

namespace CommonCore.Criterias
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

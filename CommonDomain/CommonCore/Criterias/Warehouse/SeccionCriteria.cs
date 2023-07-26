using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias.Warehouse;
using CommonCore.Criterias;

namespace CommonCore.Criterias.Warehouse
{
    public class SeccionCriteria : BaseCriteria<Seccion, long>, ISeccionCriteria
    {
        public ISeccionCriteria PorSeccion(string seccion)
        {
            _expression = x => x.Nombre.ToUpper() == seccion.ToUpper() && x.Activo;
            return this;
        }
    }
}

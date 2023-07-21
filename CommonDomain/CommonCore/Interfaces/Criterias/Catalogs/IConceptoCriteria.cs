using CommonCore.Entities.Catalogs;
using EssentialCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Catalogs
{
    public interface IConceptoCriteria : IBaseCriteria<Concepto, long>
    {
        IConceptoCriteria PorSeccion(string seccion);
    }
}

using CommonCore.Entities.Catalogs;
using EssentialCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Warehouse
{
    public interface ISeccionCriteria : IBaseCriteria<Seccion, long>
    {
        ISeccionCriteria PorSeccion(string seccion);
    }
}

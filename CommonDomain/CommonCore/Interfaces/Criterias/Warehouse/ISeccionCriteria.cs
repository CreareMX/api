using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Warehouse
{
    public interface ISeccionCriteria : IBaseCriteria<Seccion, long>
    {
        ISeccionCriteria PorSeccion(string seccion);
    }
}

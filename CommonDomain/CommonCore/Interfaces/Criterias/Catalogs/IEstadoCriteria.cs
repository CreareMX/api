using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias.Catalogs
{
    public interface IEstadoCriteria : IBaseCriteria<Estado, long>
    {
        IEstadoCriteria PorSeccion(string seccion);
    }
}

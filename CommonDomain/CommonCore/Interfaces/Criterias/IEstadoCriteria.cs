using CommonCore.Entities;
using EssentialCore.Interfaces.Criterias;

namespace CommonCore.Interfaces.Criterias
{
    public interface IEstadoCriteria : IBaseCriteria<Estado, long>
    {
        IEstadoCriteria PorSeccion(string seccion);
    }
}

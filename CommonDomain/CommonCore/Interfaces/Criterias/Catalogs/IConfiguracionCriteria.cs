using CommonCore.Entities.Catalogs;

namespace CommonCore.Interfaces.Criterias.Catalogs
{
    public interface IConfiguracionCriteria : IBaseCriteria<Configuracion, long>
    {
        IConfiguracionCriteria PorNombre(string nombre);
    }
}

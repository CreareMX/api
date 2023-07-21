using AlmacenApplication.Dtos;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IConceptoService : IService<IConceptoRepository, Concepto, long, ConceptoDto>
    {
        IList<ConceptoDto> PorSeccion(string seccion);
    }
}

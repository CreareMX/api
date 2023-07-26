using AlmacenApplication.Dtos;
using AlmacenApplication.Interfaces;
using AutoMapper;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Services;

namespace AlmacenApplication.Services
{
    public class ConceptoService : BaseService<IConceptoRepository, Concepto, long, ConceptoDto>, IConceptoService
    {
        readonly IConceptoCriteria _criteria;
        public ConceptoService(IConceptoRepository repository, IConceptoCriteria criteria, IMapper mapper) : base(repository, mapper)
        {
            _criteria = criteria;
        }

        public IList<ConceptoDto> PorSeccion(string seccion)
        {
            var result = Repository.GetListByCriteria(_criteria.PorSeccion(seccion));
            return Mapper.Map<List<ConceptoDto>>(result);
        }
    }
}

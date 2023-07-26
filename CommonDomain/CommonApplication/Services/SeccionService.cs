using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Criterias.Warehouse;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Services;

namespace CommonApplication.Services
{
    public class SeccionService : BaseService<ISeccionRepository, Seccion, long, SeccionDto>, ISeccionService
    {
        readonly ISeccionCriteria criteria;
        public SeccionService(ISeccionRepository repository, ISeccionCriteria criteria, IMapper mapper) : base(repository, mapper)
        {
            this.criteria = criteria;
        }

        public SeccionDto PorSeccion(string seccion)
        {
            if (string.IsNullOrWhiteSpace(seccion))
                throw new Exception("No se indicado un nombre de sección.");

            var entity = Repository.GetByCriteria(criteria.PorSeccion(seccion));
            return Mapper.Map<SeccionDto>(entity);
        }
    }
}

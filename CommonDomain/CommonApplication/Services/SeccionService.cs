using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class SeccionService : BaseService<ISeccionRepository, Seccion, long, SeccionDto>, ISeccionService
    {
        public SeccionService(ISeccionRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

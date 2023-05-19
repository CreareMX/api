using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
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

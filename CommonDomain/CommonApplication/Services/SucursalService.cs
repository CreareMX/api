using AutoMapper;
using CommonApplication.Dtos;
using CommonApplication.Interfaces;
using CommonCore.Entities;
using CommonCore.Interfaces.Repositories;
using EssentialCore.Services;

namespace CommonApplication.Services
{
    public class SucursalService : BaseService<ISucursalRepository, Sucursal, long, SucursalDto>, ISucursalService
    {
        public SucursalService(ISucursalRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

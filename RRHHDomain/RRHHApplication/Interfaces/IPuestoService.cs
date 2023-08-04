using CommonCore.Entities.Rrhh;
using CommonCore.Interfaces.Service;
using RRHHApplication.Dtos;
using RRHHCore.Interfaces.Repositories;

namespace RRHHApplication.Interfaces
{
    public interface IPuestoService : IService<IPuestoRepository, Puesto, long, PuestoDto>
    {
    }
}

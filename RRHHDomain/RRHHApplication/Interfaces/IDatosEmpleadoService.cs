using CommonCore.Entities.Rrhh;
using CommonCore.Interfaces.Service;
using RRHHApplication.Dtos;
using RRHHCore.Interfaces.Repositories;

namespace RRHHApplication.Interfaces
{
    public interface IDatosEmpleadoService : IService<IDatosEmpleadoRepository, DatosEmpleado, long, DatosEmpleadoDto>
    {
    }
}

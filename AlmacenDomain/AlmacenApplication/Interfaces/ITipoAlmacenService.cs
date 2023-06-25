using AlmacenApplication.Dtos;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using EssentialCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface ITipoAlmacenService : IService<ITipoAlmacenRepository, TipoAlmacen, long, TipoAlmacenDto>
    {
    }
}

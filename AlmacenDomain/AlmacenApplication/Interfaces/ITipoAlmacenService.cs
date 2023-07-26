using AlmacenApplication.Dtos;
using CommonCore.Entities.Types;
using CommonCore.Interfaces.Repositories.Types;
using CommonCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface ITipoAlmacenService : IService<ITipoAlmacenRepository, TipoAlmacen, long, TipoAlmacenDto>
    {
    }
}

using AlmacenApplication.Dtos;
using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using CommonCore.Interfaces.Service;

namespace AlmacenApplication.Interfaces
{
    public interface IGastoGeneralFijoService : IService<IGastoGeneralFijoRepository, GastoGeneralFijo, long, GastoGeneralFijoDto>
    {
        IList<GastoGeneralFijoDto> Quincenales();
        IList<GastoGeneralFijoDto> Mensuales();
        IList<GastoGeneralFijoDto> Anuales();
    }
}

using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using ContabilidadApplication.Dtos;
using EssentialCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface IDatosFiscalesService : IService<IDatosFiscalesRepository, DatosFiscales, long, DatosFiscalesDto>
    {
    }
}

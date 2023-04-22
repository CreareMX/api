using ContabilidadApplication.Dtos;
using ContabilidadCore.Entities;
using ContabilidadCore.Interfaces.Reporitories;
using EssentialCore.Interfaces.Service;

namespace ContabilidadApplication.Interfaces
{
    public interface IDatosFiscalesService : IService<IDatosFiscalesRepository, DatosFiscales, long, DatosFiscalesDto>
    {
    }
}

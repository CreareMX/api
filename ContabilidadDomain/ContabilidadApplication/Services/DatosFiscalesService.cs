using AutoMapper;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;
using ContabilidadApplication.Dtos;
using ContabilidadApplication.Interfaces;
using CommonCore.Services;

namespace ContabilidadApplication.Services
{
    public class DatosFiscalesService : BaseService<IDatosFiscalesRepository, DatosFiscales, long, DatosFiscalesDto>, IDatosFiscalesService
    {
        public DatosFiscalesService(IDatosFiscalesRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override DatosFiscalesDto Create(DatosFiscalesDto dto, long idUser)
        {
            if (string.IsNullOrWhiteSpace(dto.Domicilio) && string.IsNullOrWhiteSpace(dto.Calle) &&
                string.IsNullOrWhiteSpace(dto.Cruzamientos) && string.IsNullOrWhiteSpace(dto.Colonia))
                throw new Exception("Es necesario capturar un domicilio o bíen los elementos mínimos que lo conforman (calle, cruzamientos y colonia).");

            if (string.IsNullOrWhiteSpace(dto.Domicilio))
                dto.Domicilio = $"Calle {dto.Calle} " +
                    $"{(string.IsNullOrWhiteSpace(dto.NumeroExterior) ? "S/N" : $"No. {dto.NumeroExterior}")} " +
                    $"{(string.IsNullOrWhiteSpace(dto.NumeroInterior) ? string.Empty : $"Int. {dto.NumeroInterior}")} " +
                    $"{dto.Cruzamientos} Col. {dto.Colonia}";

            return base.Create(dto, idUser);
        }
    }
}

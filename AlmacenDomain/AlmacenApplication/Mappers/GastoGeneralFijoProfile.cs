using AlmacenApplication.Dtos;
using AutoMapper;
using CommonCore.Interfaces.Entities.Catalogs;

namespace AlmacenApplication.Mappers
{
    public class GastoGeneralFijoProfile : Profile
    {
        public GastoGeneralFijoProfile()
        {

            CreateMap<GastoGeneralFijo, GastoGeneralFijoDto>();
            CreateMap<GastoGeneralFijoDto, GastoGeneralFijo>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

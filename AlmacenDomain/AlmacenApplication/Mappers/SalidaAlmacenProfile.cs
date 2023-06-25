using AlmacenApplication.Dtos;
using AutoMapper;
using CommonCore.Entities.Warehouse;

namespace AlmacenApplication.Mappers
{
    public class SalidaAlmacenProfile : Profile
    {
        public SalidaAlmacenProfile()
        {

            CreateMap<SalidaAlmacen, SalidaAlmacenDto>();
            CreateMap<SalidaAlmacenDto, SalidaAlmacen>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

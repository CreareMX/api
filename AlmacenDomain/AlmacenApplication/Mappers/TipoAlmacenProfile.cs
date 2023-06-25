using AlmacenApplication.Dtos;
using AutoMapper;
using CommonCore.Entities.Types;

namespace AlmacenApplication.Mappers
{
    public class TipoAlmacenProfile : Profile
    {
        public TipoAlmacenProfile()
        {

            CreateMap<TipoAlmacen, TipoAlmacenDto>();
            CreateMap<TipoAlmacenDto, TipoAlmacen>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

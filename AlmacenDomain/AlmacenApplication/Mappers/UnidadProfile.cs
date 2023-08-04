using AlmacenApplication.Dtos;
using AutoMapper;
using CommonCore.Entities.Catalogs;

namespace AlmacenApplication.Mappers
{
    public class UnidadProfile : Profile
    {
        public UnidadProfile()
        {

            CreateMap<Unidad, UnidadDto>();
            CreateMap<UnidadDto, Unidad>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

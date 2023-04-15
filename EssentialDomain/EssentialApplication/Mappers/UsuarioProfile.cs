using AutoMapper;
using EssentialApplication.dtos;
using EssentialCore.Entities;

namespace EssentialApplication.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

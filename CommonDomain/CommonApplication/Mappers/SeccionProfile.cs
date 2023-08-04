using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;

namespace CommonApplication.Mappers
{
    public class SeccionProfile : Profile
    {
        public SeccionProfile()
        {

            CreateMap<Seccion, SeccionDto>();
            CreateMap<SeccionDto, Seccion>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

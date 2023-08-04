using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities.Types;

namespace CommonApplication.Mappers
{
    public class TipoPersonaProfile : Profile
    {
        public TipoPersonaProfile()
        {

            CreateMap<TipoPersona, TipoPersonaDto>();
            CreateMap<TipoPersonaDto, TipoPersona>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;

namespace CommonApplication.Mappers
{
    public class EstadoProfile : Profile
    {
        public EstadoProfile()
        {

            CreateMap<Estado, EstadoDto>();
            CreateMap<EstadoDto, Estado>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

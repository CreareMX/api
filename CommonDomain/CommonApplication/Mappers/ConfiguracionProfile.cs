using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities.Catalogs;

namespace CommonApplication.Mappers
{
    public class ConfiguracionProfile : Profile
    {
        public ConfiguracionProfile()
        {

            CreateMap<Configuracion, ConfiguracionDto>();
            CreateMap<ConfiguracionDto, Configuracion>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

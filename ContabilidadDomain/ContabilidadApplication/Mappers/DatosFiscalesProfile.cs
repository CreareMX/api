using AutoMapper;
using ContabilidadApplication.Dtos;
using ContabilidadCore.Entities;

namespace ContabilidadApplication.Mappers
{
    internal class DatosFiscalesProfile : Profile
    {
        public DatosFiscalesProfile()
        {

            CreateMap<DatosFiscales, DatosFiscalesDto>();
            CreateMap<DatosFiscalesDto, DatosFiscales>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

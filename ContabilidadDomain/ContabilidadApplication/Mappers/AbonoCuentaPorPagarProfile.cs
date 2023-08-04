using AutoMapper;
using CommonCore.Entities.Accounting;
using ContabilidadApplication.Dtos;

namespace ContabilidadApplication.Mappers
{
    internal class AbonoCuentaPorPagarProfile : Profile
    {
        public AbonoCuentaPorPagarProfile()
        {

            CreateMap<AbonoCuentaPorPagar, AbonoCuentaPorPagarDto>();
            CreateMap<AbonoCuentaPorPagarDto, AbonoCuentaPorPagar>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

using AutoMapper;
using CommonCore.Entities.Accounting;
using ContabilidadApplication.Dtos;

namespace ContabilidadApplication.Mappers
{
    internal class AbonoCuentaPorCobrarProfile : Profile
    {
        public AbonoCuentaPorCobrarProfile()
        {

            CreateMap<AbonoCuentaPorCobrar, AbonoCuentaPorCobrarDto>();
            CreateMap<AbonoCuentaPorCobrarDto, AbonoCuentaPorCobrar>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

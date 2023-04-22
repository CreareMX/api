using AutoMapper;
using ContabilidadApplication.Dtos;
using ContabilidadCore.Entities;

namespace ContabilidadApplication.Mappers
{
    internal class CuentaPorCobrarProfile : Profile
    {
        public CuentaPorCobrarProfile()
        {

            CreateMap<CuentaPorCobrar, CuentaPorCobrarDto>();
            CreateMap<CuentaPorCobrarDto, CuentaPorCobrar>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

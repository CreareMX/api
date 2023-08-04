using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities.Purchases;

namespace ComprasApplication.Mappers
{
    public class PrecioProfile : Profile
    {
        public PrecioProfile()
        {

            CreateMap<Precio, PrecioDto>();
            CreateMap<PrecioDto, Precio>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

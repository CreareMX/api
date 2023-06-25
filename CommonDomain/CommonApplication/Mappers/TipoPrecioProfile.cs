using AutoMapper;
using CommonApplication.Dtos;
using CommonCore.Entities.Types;

namespace CommonApplication.Mappers
{
    public class TipoPrecioProfile : Profile
    {
        public TipoPrecioProfile()
        {

            CreateMap<TipoPrecio, TipoPrecioDto>();
            CreateMap<TipoPrecioDto, TipoPrecio>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

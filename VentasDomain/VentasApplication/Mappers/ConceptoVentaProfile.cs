using AutoMapper;
using CommonCore.Entities.Sales;
using VentasApplication.Dtos;

namespace VentasApplication.Mappers
{
    internal class ConceptoVentaProfile : Profile
    {
        public ConceptoVentaProfile()
        {
            CreateMap<ConceptoVenta, ConceptoVentaDto>();
            CreateMap<ConceptoVentaDto, ConceptoVenta>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

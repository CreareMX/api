using AlmacenApplication.Dtos.Inventario;
using AutoMapper;
using CommonCore.Entities.Warehouse;

namespace DetalleInventarioApplication.Mappers
{
    public class DetalleInventarioProfile : Profile
    {
        public DetalleInventarioProfile()
        {

            CreateMap<DetalleInventario, DetalleInventarioDto>();
            CreateMap<DetalleInventarioDto, DetalleInventario>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

using AlmacenApplication.Dtos.Inventario;
using AutoMapper;
using CommonCore.Entities.Warehouse;

namespace InventarioApplication.Mappers
{
    public class InventarioProfile : Profile
    {
        public InventarioProfile()
        {

            CreateMap<Inventario, InventarioDto>();
            CreateMap<InventarioDto, Inventario>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

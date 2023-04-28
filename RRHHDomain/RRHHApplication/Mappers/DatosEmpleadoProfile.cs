using AutoMapper;
using RRHHApplication.Dtos;
using RRHHCore.Entities;

namespace RRHHApplication.Mappers
{
    public class DatosEmpleadoProfile : Profile
    {
        public DatosEmpleadoProfile()
        {

            CreateMap<DatosEmpleado, DatosEmpleadoDto>();
            CreateMap<DatosEmpleadoDto, DatosEmpleado>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}

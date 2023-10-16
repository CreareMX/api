﻿using AutoMapper;
using CommonCore.Entities.Sales;
using VentasApplication.Dtos;

namespace VentasApplication.Mappers
{
    public class ImpuestosConceptoVentaProfile : Profile
    {
        public ImpuestosConceptoVentaProfile()
        {
            CreateMap<ImpuestosConceptoVenta, ImpuestosConceptoVentaDto>();
            CreateMap<ImpuestosConceptoVentaDto, ImpuestosConceptoVenta>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaUltimaActualizacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioActualizaId, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreaId, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
        }
    }
}
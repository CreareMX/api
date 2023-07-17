using CommonApplication.Dtos;

namespace AlmacenApplication.Dtos
{
    public  class KardexDto
    {
        public DateTime Fecha { get; set; }
        public AlmacenDto Almacen { get; set; }
        public List<DetalleKardexDto> Detalles { get; set; }
        public List<Tuple<ProductoDto, UnidadDto>> SinExistencias { get; set; }
        public List<Tuple<ProductoDto, UnidadDto>> ExistenciasNegativas { get; set; }

        public KardexDto()
        {
            Almacen = new AlmacenDto();
            Fecha = DateTime.Now;
            Detalles = new List<DetalleKardexDto>();
            ExistenciasNegativas = new List<Tuple<ProductoDto, UnidadDto>>();
            SinExistencias = new List<Tuple<ProductoDto, UnidadDto>>();
        }

        public KardexDto(DateTime fecha, AlmacenDto almacen)
        {
            Fecha = fecha;
            Almacen = almacen;
            Detalles = new List<DetalleKardexDto>();
            SinExistencias = new List<Tuple<ProductoDto, UnidadDto>>();
            ExistenciasNegativas = new List<Tuple<ProductoDto, UnidadDto>>();
        }
    }
}

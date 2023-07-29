using CommonApplication.Dtos;

namespace AlmacenApplication.Dtos.Kardex
{
    public class KardexDto
    {
        public DateTime Fecha { get; set; }
        public ElementoKardexDto Almacen { get; set; }
        public List<DetalleKardexDto> Detalles { get; set; }
        public List<Tuple<ElementoKardexDto, ElementoKardexDto>> SinExistencias { get; set; }
        public List<Tuple<ElementoKardexDto, ElementoKardexDto>> ExistenciasNegativas { get; set; }

        public KardexDto()
        {
            Almacen = new ElementoKardexDto();
            Fecha = DateTime.Now;
            Detalles = new List<DetalleKardexDto>();
            ExistenciasNegativas = new List<Tuple<ElementoKardexDto, ElementoKardexDto>>();
            SinExistencias = new List<Tuple<ElementoKardexDto, ElementoKardexDto>>();
        }

        public KardexDto(DateTime fecha, ElementoKardexDto almacen)
        {
            Fecha = fecha;
            Almacen = almacen;
            Detalles = new List<DetalleKardexDto>();
            SinExistencias = new List<Tuple<ElementoKardexDto, ElementoKardexDto>>();
            ExistenciasNegativas = new List<Tuple<ElementoKardexDto, ElementoKardexDto>>();
        }
    }
}

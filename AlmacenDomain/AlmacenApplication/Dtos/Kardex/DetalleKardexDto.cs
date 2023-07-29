using CommonApplication.Dtos;

namespace AlmacenApplication.Dtos.Kardex
{
    public class DetalleKardexDto
    {
        public ElementoKardexDto Producto { get; set; }
        public ElementoKardexDto Unidad { get; set; }
        public List<MovimientoKardexDto> Entradas { get; set; }
        public List<MovimientoKardexDto> Salidas { get; set; }
        public decimal Existencia { get; set; }

        public DetalleKardexDto()
        {
            Entradas = new List<MovimientoKardexDto>();
            Salidas = new List<MovimientoKardexDto>();
        }
    }
}

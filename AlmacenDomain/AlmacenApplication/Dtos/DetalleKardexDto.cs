using CommonApplication.Dtos;

namespace AlmacenApplication.Dtos
{
    public class DetalleKardexDto
    {
        public ProductoDto Producto { get; set; }
        public UnidadDto Unidad { get; set; }
        public List<EntradaAlmacenDto> Entradas { get; set; }
        public List<SalidaAlmacenDto> Salidas { get; set; }
        public decimal Existencia { get; set; }

        public DetalleKardexDto()
        {
            Entradas = new List<EntradaAlmacenDto>();
            Salidas = new List<SalidaAlmacenDto>();
        }
    }
}

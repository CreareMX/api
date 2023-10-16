using CommonApplication.Dtos;
using CommonCore.Interfaces.Entities.Sales;

namespace VentasApplication.Dtos
{
    public class ConceptoVentaDto : IConceptoVenta
    {
        public long? Id { get; set; }
        public long IdVenta { get; set; }
        public long IdProducto { get; set; }
        public string Descripcion { get; set; }
        public string CodigoInterno { get; set; }
        public string UnidadInterna { get; set; }
        public string UnidadSAT { get; set; }
        public string ProdServCode { get; set; }
        public string ObjImpuesto { get; set; }
        public double? Cantidad { get; set; }
        public double? PrecioUnitario { get; set; }
        public double? Descuento { get; set; }
        public double? Total { get; set; }
        public double? TotalDescuento { get; set; }
        public string InformacionAdicional { get; set; }
        public long? IdLote { get; set; }

        public ProductoDto Producto { get; set; }

        public List<ImpuestosConceptoVentaDto> Impuestos { get; set; }
    }
}

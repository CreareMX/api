using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Sales;

namespace CommonCore.Entities.Sales
{
    public class ConceptoVenta : BaseEntityLongId, IConceptoVenta
    {
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

        public Producto Producto { get; set; }
        public List<ImpuestosConceptoVenta> Impuestos { get; set; }
    }
}

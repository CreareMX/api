using CommonCore.Entities.Catalogs;
using CommonCore.Entities.Sales;
using CommonCore.Interfaces.Entities.Sales;

namespace VentasApplication.Dtos
{
    public class VentaDto : IVenta
    {
        public long? Id { get; set; }
        public long IdCliente { get; set; }
        public long IdSucursal { get; set; }
        public string Vendedor { get; set; }
        public string Moneda { get; set; }
        public decimal? TipoCambio { get; set; }
        public string FormaPago { get; set; }
        public string Metodopago { get; set; }
        public string Serie { get; set; }
        public long Folio { get; set; }
        public double Subtotal { get; set; }
        public double? Descuento { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Estatus { get; set; }
        public long? IdEstatus { get; set; }
        public Persona Persona { get; set; }
        public Sucursal Sucursal { get; set; }
        public List<ConceptoVenta> ConceptosVenta { get; set; }

    }
}

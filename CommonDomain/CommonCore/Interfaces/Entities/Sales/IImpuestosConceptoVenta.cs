namespace CommonCore.Interfaces.Entities.Sales
{
    public interface IImpuestosConceptoVenta
    {
        long IdConceptoVenta { get; set; }
        string TipoTasaCuota { get; set; }
        string ImpuestoCode { get; set; }
        string TipoFactor { get; set; }
        string TipoImpuesto { get; set; }
        double? Base { get; set; }
        double? TasaCuota { get; set; }
        double? Importe { get; set; }
    }
}

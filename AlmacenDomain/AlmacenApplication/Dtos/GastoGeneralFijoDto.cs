using CommonCore.Interfaces.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;

namespace AlmacenApplication.Dtos
{
    public class GastoGeneralFijoDto : IGastoGeneralFijo
    {
        public long? Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public long IdConcepto { get; set; }
        public ConceptoDto Concepto { get; set; }
    }
}

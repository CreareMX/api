using CommonCore.Entities;
using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Repositories.Catalogs;

namespace CommonCore.Interfaces.Entities.Catalogs
{
    public class GastoGeneralFijo : BaseEntityLongId, IGastoGeneralFijo
    {
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public long IdConcepto { get; set; }
        public Concepto Concepto { get; set; }
    }
}

using CommonCore.Interfaces.Entities.Catalogs;

namespace CommonCore.Entities.Catalogs
{
    public class DatosFiscales : BaseEntityLongId, IDatosFiscales
    {
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string Cruzamientos { get; set; }
        public string Domicilio { get; set; }
        public string Colonia { get; set; }
        public int CodigoPostal { get; set; }
        public long? IdEntidadFederativa { get; set; }
        public string RegimenFiscal { get; set; }
        public string UsoCFDi { get; set; }
        public string Email { get; set; }

        public EntidadFederativa EntidadFederativa { get; set; }
    }
}

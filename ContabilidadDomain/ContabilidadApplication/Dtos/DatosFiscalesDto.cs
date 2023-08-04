using CommonCore.Entities.Catalogs;
using CommonCore.Interfaces.Entities.Catalogs;

namespace ContabilidadApplication.Dtos
{
    public class DatosFiscalesDto : IDatosFiscales
    {
        public long? Id { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string Calle { get; set; }
        public int CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Cruzamientos { get; set; }
        public string Domicilio { get; set; }
        public long IdEntidadFederativa { get; set; }
        public string Nombres { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public EntidadFederativa EntidadFederativa { get; set; }
    }
}

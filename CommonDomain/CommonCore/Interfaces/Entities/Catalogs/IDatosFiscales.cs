namespace CommonCore.Interfaces.Entities.Catalogs
{
    public interface IDatosFiscales
    {
        string ApellidoMaterno { get; set; }
        string ApellidoPaterno { get; set; }
        string Calle { get; set; }
        int CodigoPostal { get; set; }
        string Colonia { get; set; }
        string Cruzamientos { get; set; }
        string Domicilio { get; set; }
        long? IdEntidadFederativa { get; set; }
        string Nombres { get; set; }
        string NumeroExterior { get; set; }
        string NumeroInterior { get; set; }
        string RazonSocial { get; set; }
        string Rfc { get; set; }
        string RegimenFiscal { get; set; }
        string UsoCFDi { get; set; }
        string Email { get; set; }
    }
}

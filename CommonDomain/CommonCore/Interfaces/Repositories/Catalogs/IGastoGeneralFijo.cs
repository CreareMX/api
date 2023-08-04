namespace CommonCore.Interfaces.Repositories.Catalogs
{
    public interface IGastoGeneralFijo
    {
        string Descripcion { get; set; }
        decimal Monto { get; set; }
        long IdConcepto { get; set; }
    }
}

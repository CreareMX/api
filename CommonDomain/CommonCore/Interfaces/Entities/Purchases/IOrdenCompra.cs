namespace CommonCore.Interfaces.Entities.Purchases
{
    public interface IOrdenCompra
    {
        string Comentarios { get; set; }
        DateTime Fecha { get; set; }
        DateTime FechaCompromiso { get; set; }
        DateTime FechaEnvio { get; set; }
        string FormaEnvio { get; set; }
        long IdCliente { get; set; }
        long IdEmpleadoCrea { get; set; }
        long IdEstado { get; set; }
        long IdSucursal { get; set; }
        long IdAlmacen { get; set; }
        long? IdEmpleadoAutoriza { get; set; }
        DateTime? FechaAutorizacion { get; set; }
    }
}
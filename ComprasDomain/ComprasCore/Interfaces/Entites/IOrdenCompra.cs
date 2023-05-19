using ComprasCore.Entites;

namespace ComprasCore.Interfaces.Entites
{
    public interface IOrdenCompra
    {
        string Comentarios { get; set; }
        DateTime Fecha { get; set; }
        DateTime FechaCompromiso { get; set; }
        DateTime FechaEnvio { get; set; }
        string FormaEnvio { get; set; }
        long IdCliente { get; set; }
        long IdEmpleado { get; set; }
        long IdEstado { get; set; }
        long IdSucursal { get; set; }
    }
}
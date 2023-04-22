using ContabilidadCore.Entities;

namespace RRHHCore.Interfaces.Entities
{
    public interface IDepartamento
    {
        long IdResponsable { get; set; }
        string Nombre { get; set; }
    }
}
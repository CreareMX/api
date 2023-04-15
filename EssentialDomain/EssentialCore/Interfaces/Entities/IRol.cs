using EssentialCore.Entities;

namespace EssentialCore.Interfaces.Entities
{
    public interface IRol : IBaseEntity<long>
    {
        string Nombre { get; set; }
    }
}

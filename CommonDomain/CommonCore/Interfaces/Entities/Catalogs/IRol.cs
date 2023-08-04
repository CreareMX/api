using CommonCore.Entities;

namespace CommonCore.Interfaces.Entities
{
    public interface IRol : IBaseEntity<long>
    {
        string Nombre { get; set; }
    }
}

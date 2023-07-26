using CommonCore.Entities;

namespace CommonCore.Interfaces.Entities
{
    public interface IPermisosRol : IBaseEntity<long>
    {
        long PermisoId { get; set; }
        long RolId { get; set; }
    }
}

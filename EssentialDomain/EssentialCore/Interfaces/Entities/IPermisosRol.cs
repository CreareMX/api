namespace EssentialCore.Interfaces.Entities
{
    public interface IPermisosRol : IBaseEntity<long>
    {
        IList<IPermiso> Permisos { get; set; }
        long RolId { get; set; }
        IRol Rol { get; set; }
    }
}

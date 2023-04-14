using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Entities
{
    public class PermisosRol : BaseEntityLongId, IPermisosRol
    {
        public IList<IPermiso> Permisos { get; set; }
        public long RolId { get; set; }
        public IRol Rol { get; set; }
    }
}

using EssentialCore.Interfaces.Entities;

namespace EssentialApplication.dtos
{
    public class PermisosRolDto : IPermisosRol
    {
        public IList<IPermiso> Permisos { get; set; }
        public long RolId { get; set; }
        public IRol Rol { get; set; }
        public long Id { get; set; }
    }
}

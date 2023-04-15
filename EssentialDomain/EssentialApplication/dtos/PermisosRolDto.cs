using EssentialCore.Entities;
using EssentialCore.Interfaces.Entities;

namespace EssentialApplication.dtos
{
    public class PermisosRolDto : IPermisosRol
    {
        public long PermisoId { get; set; }
        public long RolId { get; set; }
        public long? Id { get; set; }
    }
}

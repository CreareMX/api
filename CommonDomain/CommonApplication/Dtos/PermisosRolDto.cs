using CommonCore.Entities;
using CommonCore.Interfaces.Entities;

namespace CommonApplication.dtos
{
    public class PermisosRolDto : IPermisosRol
    {
        public long PermisoId { get; set; }
        public long RolId { get; set; }
        public long? Id { get; set; }
    }
}

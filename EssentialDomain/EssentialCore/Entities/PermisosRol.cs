using EssentialCore.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities
{
    public class PermisosRol : BaseEntityLongId, IPermisosRol
    {
        public IList<IPermiso> Permisos { get; set; }
        public long RolId { get; set; }
        public IRol Rol { get; set; }
    }
}

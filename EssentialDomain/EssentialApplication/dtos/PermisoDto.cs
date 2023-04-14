using EssentialCore.Interfaces.Entities;

namespace EssentialApplication.dtos
{
    public class PermisoDto : IPermiso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Id { get; set; }
    }
}

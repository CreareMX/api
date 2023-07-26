using CommonCore.Interfaces.Entities;

namespace CommonApplication.dtos
{
    public class PermisoDto : IPermiso
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string RutaAcceso { get; set; }
        public long? Id { get; set; }
    }
}

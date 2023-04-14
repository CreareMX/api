using EssentialCore.Interfaces.Entities;

namespace EssentialApplication.dtos
{
    public class RolDto : IRol
    {
        public string Nombre { get; set; }
        public long Id { get; set; }
        public IList<IUsuario> Usuarios { get; set; }
    }
}

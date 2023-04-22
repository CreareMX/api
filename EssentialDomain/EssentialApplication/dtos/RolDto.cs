using EssentialCore.Interfaces.Entities;
using System.Diagnostics.CodeAnalysis;

namespace EssentialApplication.dtos
{
    public class RolDto : IRol
    {
        public string Nombre { get; set; }
        public long? Id { get; set; }
        public List<UsuarioDto> Usuarios { get; set; }
    }
}

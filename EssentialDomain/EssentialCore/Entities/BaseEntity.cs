using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Entities
{
    public class BaseEntity<T> : IBaseEntity<T>, IControlFields<T> where T : struct
    {
        public T Id { get; set; }
        public bool Activo { get; private set; }
        public DateTime FehaCreacion { get; private set; }
        public DateTime? FechaUltimaActualizacion { get; private set; }
        public T UsuarioCreaId { get; private set; }
        public T? UsuarioActualizaId { get; private set; }

        public void New(T userId)
        {
            Activo = true;
            FehaCreacion = DateTime.UtcNow;
            UsuarioCreaId = userId;
        }

        public void Update(T userId)
        {
            FechaUltimaActualizacion = DateTime.UtcNow;
            UsuarioActualizaId = userId;
        }

        public void Deactivate(T userId)
        {
            Activo = false;
            FechaUltimaActualizacion = DateTime.UtcNow;
            UsuarioActualizaId = userId;
        }
    }
}

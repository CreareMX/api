using CommonCore.Interfaces.Entities;

namespace CommonCore.Entities
{
    public class BaseEntity<T> : IBaseEntity<T>, IControlFields where T : struct
    {
        public T? Id { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public long UsuarioCreaId { get; set; }
        public long? UsuarioActualizaId { get; set; }
        public Usuario UsuarioCrea { get; set; }
        public Usuario UsuarioActualiza { get; set; }

        public void New(T userId)
        {
            Id = default;
            Activo = true;
            FechaCreacion = DateTime.UtcNow;
            if (long.TryParse(userId.ToString(), out long id))
                UsuarioCreaId = id;
        }

        public void Update(T userId)
        {
            FechaUltimaActualizacion = DateTime.UtcNow;
            if (long.TryParse(userId.ToString(), out long id))
                UsuarioActualizaId = id;
        }

        public void Deactivate(T userId)
        {
            Activo = false;
            FechaUltimaActualizacion = DateTime.UtcNow;
            if (long.TryParse(userId.ToString(), out long id))
                UsuarioActualizaId = id;
        }
    }
}

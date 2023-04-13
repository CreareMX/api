using EssentialCore.Interfaces.Entities;

namespace EssentialCore.Entities
{
    public class BaseEntity<T> : IBaseEntity<T>, IControlFields<T> where T : struct
    {
        public T Id { get; set; }
        public bool IsActive { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }
        public T CreationUser { get; private set; }
        public T? LastUpdateUser { get; private set; }

        public void New(T userId)
        {
            IsActive = true;
            CreationDate = DateTime.UtcNow;
            CreationUser = userId;
        }

        public void Update(T userId)
        {
            LastUpdateDate = DateTime.UtcNow;
            LastUpdateUser = userId;
        }

        public void Deactivate(T userId)
        {
            IsActive = false;
            LastUpdateDate = DateTime.UtcNow;
            LastUpdateUser = userId;
        }
    }
}

namespace EssentialCore.Interfaces.Entities
{
    public interface IControlFields<T> where T : struct
    {
        bool IsActive { get; }
        DateTime CreationDate { get; }
        DateTime? LastUpdateDate { get; }
        T CreationUser { get; }
        T? LastUpdateUser { get; }
    }
}

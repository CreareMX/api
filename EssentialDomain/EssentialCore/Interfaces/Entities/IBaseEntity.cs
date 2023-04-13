namespace EssentialCore.Interfaces.Entities
{
    public interface IBaseEntity<t> where t : struct
    {
        t Id { get; set; }
    }
}

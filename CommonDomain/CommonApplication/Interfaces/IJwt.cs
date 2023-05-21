namespace CommonApplication.Interfaces
{
    public interface IJwt
    {
        string Audience { get; set; }
        string Issuer { get; set; }
        string Key { get; set; }
        int ExpirationSeconds { get; set; }
    }
}
using CommonApplication.Interfaces;

namespace CommonApplication.Dtos
{
    public class Jwt : IJwt
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpirationSeconds { get; set; }
    }
}

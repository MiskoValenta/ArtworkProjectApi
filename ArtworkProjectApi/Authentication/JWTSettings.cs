using Microsoft.Identity.Client;

namespace ArtworkProjectApi.Authentication
{
    public class JWTSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}

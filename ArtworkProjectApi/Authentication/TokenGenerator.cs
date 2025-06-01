using ArtworkProjectApi.Authentication;
using ArtworkProjectApi.Authentication.Interface;
using ArtworkProjectApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArtworkProjectApiAuthentication
{
    public class TokenGenerator : ITokenService
    {
        private readonly JWTSettings _jwtSettings;

        public TokenGenerator(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Admin admin)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // IMPROVED: Use proper ClaimTypes for better ASP.NET Core integration
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, admin.Username),
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin"), // ✅ Use ClaimTypes.Role instead of "role"
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Token ID for revocation
                new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64) // Issued at time
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
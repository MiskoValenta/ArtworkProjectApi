using ArtworkProjectApi.Models;

namespace ArtworkProjectApi.Authentication.Interface
{
    public interface ITokenService
    {
        string GenerateToken(Admin admin);
    }
}

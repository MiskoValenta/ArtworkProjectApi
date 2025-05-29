using ArtworkProjectApi.DTOs;

namespace ArtworkProjectApi.Services.Interfaces
{
    public interface IAdminAuthService
    {
        Task<string?> LoginAsync(AdminLoginDto loginDto);
    }
}
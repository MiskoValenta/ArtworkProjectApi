using ArtworkProjectApi.Authentication.Interface;
using ArtworkProjectApi.Data;
using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ArtworkProjectApi.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AdminAuthService> _logger;

        public AdminAuthService(AppDbContext context, ITokenService tokenService, ILogger<AdminAuthService> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _logger = logger;
        }
        public async Task<string?> LoginAsync(AdminLoginDto loginDto)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Username == loginDto.Username);
            if (admin == null)
            {
                _logger.LogWarning("Pokus o přihlášení s neexistujícím uživatelským jménem: {Username}", loginDto.Username);
                return null;
            }

            if (!VerifyPassword(loginDto.Password, admin.PasswordHash, admin.PasswordSalt))
            {
                _logger.LogWarning("Neplatné heslo pro uživatele: {Username}", loginDto.Username);
                return null;
            }

            return _tokenService.GenerateToken(admin);
        }
        private bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(hash);
        }
    }
}

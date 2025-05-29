using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtworkProjectApi.Controllers
{
    [ApiController]
    [Route("store/[controller]")]
    public class AdminAuthController : ControllerBase
    {
        private readonly IAdminAuthService _authService;

        public AdminAuthController(IAdminAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized(new { message = "Neplatné přihlašovací údaje." });
            }

            return Ok(new { token });
        }
    }
}

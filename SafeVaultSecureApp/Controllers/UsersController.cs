using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafeVaultSecureApp.Services;

namespace SafeVaultSecureApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UsersController(IAuthService authService) => _authService = authService;

        [HttpPost("login")]
        public IActionResult Login([FromQuery] string username, [FromQuery] string role)
        {
            var token = _authService.GenerateJwtToken(username, role);
            return Ok(new { token });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult GetAdminData()
        {
            return Ok("Sensitive admin data");
        }
    }
}

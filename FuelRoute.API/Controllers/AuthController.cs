using Microsoft.AspNetCore.Mvc;
using FuelRoute.Core.Interfaces;
using FuelRoute.Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace FuelRoute.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        // 🔐 PROTECTED ENDPOINT
        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedTest()
        {
            return Ok(new
            {
                Message = "You accessed a protected endpoint!",
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }
    }
}

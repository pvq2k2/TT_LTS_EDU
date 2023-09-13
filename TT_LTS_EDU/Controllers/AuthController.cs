using Microsoft.AspNetCore.Mvc;
using TT_LTS_EDU.Handle.DTOs;
using TT_LTS_EDU.Handle.Request.AuthRequest;
using TT_LTS_EDU.Handle.Response;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _iAuthService;
        public AuthController(IAuthService iAuthService) {
            _iAuthService = iAuthService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            return Ok(await _iAuthService.Register(request));
        }

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(string token)
        {
            return Ok(await _iAuthService.VerifyEmail(token));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return Ok(await _iAuthService.Login(request));
        }

        [HttpPost("ReNewToken")]
        public IActionResult ReNewToken(string refreshToken)
        {
            return Ok(_iAuthService.ReNewToken(refreshToken));
        }
    }
}

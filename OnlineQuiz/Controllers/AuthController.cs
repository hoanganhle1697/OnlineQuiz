using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Application.DTOs;
using OnlineQuiz.Application.Services.Interfaces;

namespace OnlineQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInDto signInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authServices.LoginAsync(signInDto);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(new { Token = result });
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] SignUpDto signUpDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authServices.RegisterAsync(signUpDto);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(e => e.Description));
            }
            return Ok(result.Succeeded);
        }
    }
}


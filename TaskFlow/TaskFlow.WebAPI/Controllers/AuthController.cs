using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.AuthDTOs;
using TaskFlow.Application.IRepository;

namespace TaskFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [HttpPost("user/register")]
        public async Task<IActionResult> UserRegister([FromBody] AddUserRequest addUserRequest)
        {
            var user = await authRepository.RegisterAsync(addUserRequest);
            if (user == null)
            {
                return BadRequest("User already exists or registration failed.");
            }
            return Ok(user);
        }

        [HttpPost("admin/register")]
        public async Task<IActionResult> AdminRegister([FromBody] AddUserRequest addUserRequest)
        {
            var user = await authRepository.RegisterAsync(addUserRequest);
            if (user == null)
            {
                return BadRequest("User already exists or registration failed.");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            var token = await authRepository.LoginAsync(loginRequest);
            if (token == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(new { Token = token });
        }
    }
}

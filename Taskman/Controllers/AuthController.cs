using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
         
            // Validate user
            if (user.Username != "admin") 
            {
                return Unauthorized("Invalid credentials");
            }

            // Generate JWT token
            var token = _tokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}

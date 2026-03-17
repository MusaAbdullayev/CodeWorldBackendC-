using ApiHelloBL.DTOs.AuthDTO;
using ApiHelloBL.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO dto)
        {
           var token= await _service.LoginAsync(dto);
            return Ok(new { Token = token });
        }
        [HttpPost("Role")]
        public async Task<IActionResult> Role()
        {
            await _service.Role();
            return Ok();
        }
    }
}

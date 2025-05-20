using Core.Aventureo.Dto;
using Core.Aventureo.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthController : ControllerBase
    {
        private readonly IJwtAuthService _service;

        public JwtAuthController(IJwtAuthService service)
        {
            _service = service;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDTO cuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var token = await _service.Login(cuenta);
                return Ok(token);
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al generar el token", details = ex.Message });
            }
        }


        [HttpPost("Register")]
        public async Task<ActionResult<TokenDto>> Register(RegisterUserDTO user)
        {
                if (!ModelState.IsValid)
                {
                throw new Exception("ModelState is not valid");
                }
                var token = await _service.RegisterUser(user);
                return Ok(token);
        }

    }
}

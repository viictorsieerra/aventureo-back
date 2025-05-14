using Aventureo_Back.DTO;
using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aventureo_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthController : ControllerBase
    {
        private readonly IJwtAuthService? _service;

        public JwtAuthController(IJwtAuthService? service) {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO cuenta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                string token = await _service.Login(cuenta);
                return Ok(token);
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(ex);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al generar el token");
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                string token = await _service.RegisterUser(user);
                return Ok(token);
            }
            catch (KeyNotFoundException ex)
            {
                return Unauthorized(ex);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al generar el token");
            }
        }

    }
}

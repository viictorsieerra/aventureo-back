using Microsoft.AspNetCore.Mvc;
using AventureoBack.Models;  

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok("usuarios");
        }

    
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            return Ok(usuario);
        }
    }
}

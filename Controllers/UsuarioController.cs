using AventureoBack.Models;
using AventureoBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAllAsync()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int idUsuario)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(idUsuario);
                if (usuario == null)
                {
                    return NotFound(new { Message = "Usuario no encontrado" });
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> AddAsync([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(new { Message = "El objeto Usuario no puede ser nulo" });
            }

            try
            {
                var newUsuario = await _usuarioService.AddAsync(usuario);
                return CreatedAtAction(nameof(GetByIdAsync), new { idUsuario = newUsuario.idUsuario }, newUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

       
        [HttpPut("{idUsuario}")]
        public async Task<ActionResult<Usuario>> UpdateAsync(int idUsuario, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.idUsuario != idUsuario)
            {
                return BadRequest(new { Message = "El objeto Usuario es inválido o el ID no coincide." });
            }

            try
            {
                var updatedUsuario = await _usuarioService.UpdateAsync(usuario);
                return Ok(updatedUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

       
        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteAsync(int idUsuario)
        {
            try
            {
                await _usuarioService.DeleteAsync(idUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}

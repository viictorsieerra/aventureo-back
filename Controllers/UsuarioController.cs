using Microsoft.AspNetCore.Mvc;
using AventureoBack.Models;  

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { idUsuario = 1, Nombre = "Juan", Apellidos = "Pérez", FecNacimiento = new DateTime(1990, 1, 1), Email = "juan@ejemplo.com", Contraseña = "12345" },
            new Usuario { idUsuario = 2, Nombre = "María", Apellidos = "García", FecNacimiento = new DateTime(1992, 5, 14), Email = "maria@ejemplo.com", Contraseña = "12345" }
        };

        
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(usuarios);
        }

    
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            usuario.idUsuario = usuarios.Count + 1;  
            usuarios.Add(usuario);

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.idUsuario }, usuario);
        }
    }
}

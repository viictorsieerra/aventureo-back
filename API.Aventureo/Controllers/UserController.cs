using System.Security.Claims;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAllAsync()
        {

            var Usuarios = await _service.GetAllAsync();
            return Ok(Usuarios);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int idUsuario)
        {

            var Usuario = await _service.GetByIdAsync(idUsuario);

            return Ok(Usuario);

        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("Auth")]
        public async Task<ActionResult<Usuario>> GetByToken()
        {
            Usuario? user = await _service.GetByToken(User);

            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AddModUserDTO>> AddAsync([FromBody] AddModUserDTO Usuario)
        {

            var newUsuario = await _service.AddAsync(Usuario);
            return Ok(newUsuario);

        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateAsync([FromBody] AddModUserDTO Usuario)
        {

            var updatedUsuario = await _service.UpdateAsync(Usuario);
            return Ok(updatedUsuario);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteAsync(int idUsuario)
        {

            await _service.DeleteAsync(idUsuario);
            return NoContent();
        }
    }
}

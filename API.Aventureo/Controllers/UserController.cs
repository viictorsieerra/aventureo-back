using Application.Aventureo.Services;
using Core.Aventureo.Dto;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
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


        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAllAsync()
        {

            var Usuarios = await _service.GetAllAsync();
            return Ok(Usuarios);

        }


        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Usuario>> GetByIdAsync(int idUsuario)
        {

            var Usuario = await _service.GetByIdAsync(idUsuario);

            return Ok(Usuario);

        }


        [HttpPost]
        public async Task<ActionResult<AddModUserDTO>> AddAsync([FromBody] AddModUserDTO Usuario)
        {

            var newUsuario = await _service.AddAsync(Usuario);
            return Ok(newUsuario);

        }


        [HttpPut]
        public async Task<ActionResult<Usuario>> UpdateAsync([FromBody] AddModUserDTO Usuario)
        {

            var updatedUsuario = await _service.UpdateAsync(Usuario);
            return Ok(updatedUsuario);

        }


        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteAsync(int idUsuario)
        {

            await _service.DeleteAsync(idUsuario);
            return NoContent();
        }
    }
}

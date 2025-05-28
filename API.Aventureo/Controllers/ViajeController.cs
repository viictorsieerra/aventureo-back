using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeService _service;

        public ViajeController (IViajeService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Viaje>>> GetAllAsync()
        {

            var viajes = await _service.GetAllAsync();
            return Ok(viajes);
        }


        [HttpGet("{idViaje}")]
        public async Task<ActionResult<Viaje>> GetByIdAsync(int idViaje)
        {

            var Viaje = await _service.GetByIdAsync(idViaje);

            return Ok(Viaje);

        }

        [HttpGet("Auth")]
        public async Task<ActionResult<List<Viaje>>> GetViajesByUser()
        {
            List<Viaje> result = await _service.GetViajeByUser(User);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<CreateViajeDTO>> AddAsync([FromBody] CreateViajeDTO Viaje)
        {

            var newViaje = await _service.AddAsync(Viaje);
            return Ok(newViaje);

        }


        [HttpPut]
        public async Task<ActionResult<Viaje>> UpdateAsync([FromBody] UpdateViajeDTO Viaje)
        {

            var updatedViaje = await _service.UpdateAsync(Viaje);
            return Ok(updatedViaje);

        }


        [HttpDelete("{idViaje}")]
        public async Task<IActionResult> DeleteAsync(int idViaje)
        {

            await _service.DeleteAsync(idViaje);
            return NoContent();
        }
    }
}

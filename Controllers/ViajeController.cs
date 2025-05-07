using AventureoBack.Models;
using AventureoBack.Services;
using Microsoft.AspNetCore.Mvc;

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeService _viajeService;

        public ViajeController(IViajeService viajeService)
        {
            _viajeService = viajeService ?? throw new ArgumentNullException(nameof(viajeService));
        }

       
        [HttpGet]
        public async Task<ActionResult<List<Viaje>>> GetAllAsync()
        {
            try
            {
                var viajes = await _viajeService.GetAllAsync();
                return Ok(viajes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

    
        [HttpGet("{idViaje}")]
        public async Task<ActionResult<Viaje>> GetByIdAsync(int idViaje)
        {
            try
            {
                var viaje = await _viajeService.GetByIdAsync(idViaje);
                if (viaje == null)
                {
                    return NotFound(new { Message = "Viaje no encontrado" });
                }
                return Ok(viaje);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Viaje>> AddAsync([FromBody] Viaje viaje)
        {
            if (viaje == null)
            {
                return BadRequest(new { Message = "El objeto viaje no puede ser nulo" });
            }

            try
            {
                var newViaje = await _viajeService.AddAsync(viaje);
                return CreatedAtAction(nameof(GetByIdAsync), new { idViaje = newViaje.idViaje }, newViaje);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpPut("{idViaje}")]
        public async Task<ActionResult<Viaje>> UpdateAsync(int idViaje, [FromBody] Viaje viaje)
        {
            if (viaje == null || viaje.idViaje != idViaje)
            {
                return BadRequest(new { Message = "El objeto viaje es inválido o el ID no coincide." });
            }

            try
            {
                var updatedViaje = await _viajeService.UpdateAsync(viaje);
                return Ok(updatedViaje);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

       
        [HttpDelete("{idViaje}")]
        public async Task<IActionResult> DeleteAsync(int idViaje)
        {
            try
            {
                await _viajeService.DeleteAsync(idViaje);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}

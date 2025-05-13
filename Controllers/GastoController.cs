using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly IGastoService _gastoService;

        public GastoController(IGastoService gastoService)
        {
            _gastoService = gastoService ?? throw new ArgumentNullException(nameof(gastoService));
        }

    
        [HttpGet]
        public async Task<ActionResult<List<Gasto>>> GetAllAsync()
        {
            try
            {
                var gastos = await _gastoService.GetAllAsync();
                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

      
        [HttpGet("{idGasto}")]
        public async Task<ActionResult<Gasto>> GetByIdAsync(int idGasto)
        {
            try
            {
                var gasto = await _gastoService.GetByIdAsync(idGasto);
                if (gasto == null)
                {
                    return NotFound(new { Message = "Gasto no encontrado" });
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

     
        [HttpPost]
        public async Task<ActionResult<Gasto>> AddAsync([FromBody] Gasto gasto)
        {
            if (gasto == null)
            {
                return BadRequest(new { Message = "El objeto Gasto no puede ser nulo" });
            }

            try
            {
                var newGasto = await _gastoService.AddAsync(gasto);
                return CreatedAtAction(nameof(GetByIdAsync), new { idGasto = newGasto.idGasto }, newGasto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPut("{idGasto}")]
        public async Task<ActionResult<Gasto>> UpdateAsync(int idGasto, [FromBody] Gasto gasto)
        {
            if (gasto == null || gasto.idGasto != idGasto)
            {
                return BadRequest(new { Message = "El objeto Gasto es inválido o el ID no coincide." });
            }

            try
            {
                var updatedGasto = await _gastoService.UpdateAsync(gasto);
                return Ok(updatedGasto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpDelete("{idGasto}")]
        public async Task<IActionResult> DeleteAsync(int idGasto)
        {
            try
            {
                await _gastoService.DeleteAsync(idGasto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}

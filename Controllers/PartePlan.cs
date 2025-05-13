using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartePlanController : ControllerBase
    {
        private readonly IPartePlanService _partePlanService;

        public PartePlanController(IPartePlanService partePlanService)
        {
            _partePlanService = partePlanService ?? throw new ArgumentNullException(nameof(partePlanService));
        }

     
        [HttpGet]
        public async Task<ActionResult<List<PartePlan>>> GetAllAsync()
        {
            try
            {
                var partesPlan = await _partePlanService.GetAllAsync();
                return Ok(partesPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

   
        [HttpGet("{idPartePlan}")]
        public async Task<ActionResult<PartePlan>> GetByIdAsync(int idPartePlan)
        {
            try
            {
                var partePlan = await _partePlanService.GetByIdAsync(idPartePlan);
                if (partePlan == null)
                {
                    return NotFound(new { Message = "PartePlan no encontrado" });
                }
                return Ok(partePlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

      
        [HttpPost]
        public async Task<ActionResult<PartePlan>> AddAsync([FromBody] PartePlan partePlan)
        {
            if (partePlan == null)
            {
                return BadRequest(new { Message = "El objeto PartePlan no puede ser nulo" });
            }

            try
            {
                var newPartePlan = await _partePlanService.AddAsync(partePlan);
                return CreatedAtAction(nameof(GetByIdAsync), new { idPartePlan = newPartePlan.idPartePlan }, newPartePlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpPut("{idPartePlan}")]
        public async Task<ActionResult<PartePlan>> UpdateAsync(int idPartePlan, [FromBody] PartePlan partePlan)
        {
            if (partePlan == null || partePlan.idPartePlan != idPartePlan)
            {
                return BadRequest(new { Message = "El objeto PartePlan es inválido o el ID no coincide." });
            }

            try
            {
                var updatedPartePlan = await _partePlanService.UpdateAsync(partePlan);
                return Ok(updatedPartePlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpDelete("{idPartePlan}")]
        public async Task<IActionResult> DeleteAsync(int idPartePlan)
        {
            try
            {
                await _partePlanService.DeleteAsync(idPartePlan);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}

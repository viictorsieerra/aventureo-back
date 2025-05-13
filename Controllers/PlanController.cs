using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace AventureoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService ?? throw new ArgumentNullException(nameof(planService));
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Plan>>> GetAllAsync()
        {
            try
            {
                var planes = await _planService.GetAllAsync();
                return Ok(planes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

      
        [HttpGet("{idPlan}")]
        public async Task<ActionResult<Plan>> GetByIdAsync(int idPlan)
        {
            try
            {
                var plan = await _planService.GetByIdAsync(idPlan);
                if (plan == null)
                {
                    return NotFound(new { Message = "Plan no encontrado" });
                }
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Plan>> AddAsync([FromBody] Plan plan)
        {
            if (plan == null)
            {
                return BadRequest(new { Message = "El objeto plan no puede ser nulo" });
            }

            try
            {
                var newPlan = await _planService.AddAsync(plan);
                return CreatedAtAction(nameof(GetByIdAsync), new { idPlan = newPlan.idPlan }, newPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

       
        [HttpPut("{idPlan}")]
        public async Task<ActionResult<Plan>> UpdateAsync(int idPlan, [FromBody] Plan plan)
        {
            if (plan == null || plan.idPlan != idPlan)
            {
                return BadRequest(new { Message = "El objeto plan es inválido o el ID no coincide." });
            }

            try
            {
                var updatedPlan = await _planService.UpdateAsync(plan);
                return Ok(updatedPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        [HttpDelete("{idPlan}")]
        public async Task<IActionResult> DeleteAsync(int idPlan)
        {
            try
            {
                await _planService.DeleteAsync(idPlan);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}

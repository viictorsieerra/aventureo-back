using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _service;

        public PlanController(IPlanService PlanService)
        {
            _service = PlanService ?? throw new ArgumentNullException(nameof(PlanService));
        }

        [HttpGet]
        public async Task<ActionResult<List<Plan>>> GetAllAsync()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{idPlan}")]
        public async Task<ActionResult<Plan>> GetByIdAsync(int idPlan)
        {
            var plan = await _service.GetByIdAsync(idPlan);
            if (plan == null)
                return NotFound($"No se encontró plan con id {idPlan}");

            return Ok(plan);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePlanDTO>> AddAsync([FromBody] CreatePlanDTO planDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newPlan = await _service.AddAsync(planDto);
                return Ok(newPlan);
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear ex.Message
                return StatusCode(500, "Error al crear el plan: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Plan>> UpdateAsync([FromBody] UpdatePlanDTO planDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedPlan = await _service.UpdateAsync(planDto);
                return Ok(updatedPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al actualizar el plan: " + ex.Message);
            }
        }

        [HttpDelete("{idPlan}")]
        public async Task<IActionResult> DeleteAsync(int idPlan)
        {
            try
            {
                await _service.DeleteAsync(idPlan);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al eliminar el plan: " + ex.Message);
            }
        }

        [HttpGet("byLugar")]
        public async Task<ActionResult<List<Plan>>> GetByLugarAsync([FromQuery] string lugar)
        {
            var planes = await _service.GetByLugarAsync(lugar);
            return Ok(planes);
        }
    }
}

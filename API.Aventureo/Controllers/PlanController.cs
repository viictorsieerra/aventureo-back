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

            return Ok(plan);

        }

        [HttpGet("Lugar/{lugar}")]
        public async Task <ActionResult<List<Plan>>> GetPlansByLugar(string lugar)
        {
            List<Plan> result = await _service.GetPlansByLugar(lugar);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePlanDTO>> AddAsync([FromBody] CreatePlanDTO Plan)
        {

            var newPlan = await _service.AddAsync(Plan);
            return Ok(newPlan);

        }


        [HttpPut]
        public async Task<ActionResult<Plan>> UpdateAsync([FromBody] UpdatePlanDTO Plan)
        {

            var updatedPlan = await _service.UpdateAsync(Plan);
            return Ok(updatedPlan);

        }


        [HttpDelete("{idPlan}")]
        public async Task<IActionResult> DeleteAsync(int idPlan)
        {

            await _service.DeleteAsync(idPlan);
            return NoContent();
        }
    }
}

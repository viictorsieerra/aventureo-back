using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartePlanController : ControllerBase
    {
        private readonly IPartePlanService _service;

        public PartePlanController(IPartePlanService PartePlanService)
        {
            _service = PartePlanService ?? throw new ArgumentNullException(nameof(PartePlanService));
        }


        [HttpGet]
        public async Task<ActionResult<List<PartePlan>>> GetAllAsync()
        {

            var PartePlans = await _service.GetAllAsync();
            return Ok(PartePlans);
        }


        [HttpGet("{idPartePlan}")]
        public async Task<ActionResult<PartePlan>> GetByIdAsync(int idPartePlan)
        {

            var PartePlan = await _service.GetByIdAsync(idPartePlan);

            return Ok(PartePlan);

        }

        [HttpGet("Plan/{idPlan}")]
        public async Task<ActionResult<List<PartePlan>>> GetActividades (int idPlan)
        {
            List<PartePlan> result = await _service.GetActividades(idPlan);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePartePlanDTO>> AddAsync([FromBody] CreatePartePlanDTO PartePlan)
        {

            var newPartePlan = await _service.AddAsync(PartePlan);
            return Ok(newPartePlan);

        }


        [HttpPut]
        public async Task<ActionResult<PartePlan>> UpdateAsync([FromBody] UpdatePartePlanDTO PartePlan)
        {

            var updatedPartePlan = await _service.UpdateAsync(PartePlan);
            return Ok(updatedPartePlan);

        }


        [HttpDelete("{idPartePlan}")]
        public async Task<IActionResult> DeleteAsync(int idPartePlan)
        {

            await _service.DeleteAsync(idPartePlan);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.ExternalCommunication;
namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private readonly IAIService _service;

        public AIController(IAIService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetChatResponse([FromBody] UserMessage userMessage)
        {
            var reply = await _service.GetChatResponse(userMessage.Message);
            return Ok(new { reply });
        }
    }
}

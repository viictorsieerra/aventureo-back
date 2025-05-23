using Application.Aventureo.ExternalCommunication;
using Microsoft.AspNetCore.Mvc;
using Core.Aventureo.DTO;
namespace API.Aventureo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private readonly AIService _service;

        public AIController(AIService service)
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

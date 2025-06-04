using Microsoft.AspNetCore.Mvc;
using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.ExternalCommunication;
using Microsoft.AspNetCore.Authorization;
namespace API.Aventureo.Controllers
{
    [Authorize(Roles ="User,Admin")]
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
        public async Task<IActionResult> GetChatResponse([FromBody] List<AIMessages> mensajes)
        {
            var reply = await _service.GetChatResponse(mensajes);
            return Ok(new { reply });
        }
    }
}

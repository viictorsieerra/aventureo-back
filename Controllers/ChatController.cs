// ChatController.cs
using Microsoft.AspNetCore.Mvc;
using TuProyecto.Services;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly OpenAIService _openAIService;

        public ChatController(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserMessage userMessage)
        {
            var reply = await _openAIService.GetChatResponse(userMessage.Message);
            return Ok(new { reply });
        }
    }

    public class UserMessage
    {
        public required string Message { get; set; }
    }
}

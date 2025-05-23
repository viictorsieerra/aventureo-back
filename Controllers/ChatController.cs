
using Microsoft.AspNetCore.Mvc;
using AventureoBack.Services;

namespace AventureoBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IAiService _aiService;

        public ChatController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserMessage userMessage)
        {
            var reply = await _aiService.GetResponseAsync(userMessage.Message);
            return Ok(new { reply });
        }
    }

    public class UserMessage
    {
        public required string Message { get; set; }
    }
}

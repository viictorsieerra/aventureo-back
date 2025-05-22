// ChatController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IAiService _aiService;
    
    public ChatController(IAiService aiService)
    {
        _aiService = aiService;
    }
    
    [HttpPost("ask")]
    public async Task<IActionResult> AskQuestion([FromBody] ChatRequest request)
    {
        try
        {
            // Puedes añadir contexto específico para tu dominio (turismo)
            string prompt = $"Eres un asistente de viajes especializado en España. Responde de forma concisa y útil. {request.Question}";
            
            var response = await _aiService.GetResponseAsync(prompt);
            return Ok(new ChatResponse { Answer = response });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al procesar la pregunta: {ex.Message}");
        }
    }
}

// Modelos
public class ChatRequest
{
    public string Question { get; set; }
}

public class ChatResponse
{
    public string Answer { get; set; }
}
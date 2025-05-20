using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;

    public ChatController(ChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost("mensaje")]
    public async Task<IActionResult> EnviarMensaje([FromBody] MensajeDTO mensaje)
    {
        var respuesta = await _chatService.ObtenerRespuestaIA(mensaje.Texto);
        return Ok(new { respuesta });
    }
}

public class MensajeDTO
{
    public string Texto { get; set; }
}

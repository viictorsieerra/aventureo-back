// IAiService.cs
using System.Net.Http.Headers;

public interface IAiService
{
    Task<string> GetResponseAsync(string prompt);
}

// OpenAIService.cs
public class OpenAIService : IAiService
{
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;
    
    public OpenAIService(IConfiguration config, HttpClient httpClient)
    {
        _config = config;
        _httpClient = httpClient;
    }
    
    public async Task<string> GetResponseAsync(string prompt)
    {
        var apiKey = _config["OpenAI:ApiKey"];
        var request = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "Eres un asistente de viajes especializado en España." },
                new { role = "user", content = prompt }
            },
            temperature = 0.7
        };
        
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        
        var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
        return result?.Choices?.FirstOrDefault()?.Message?.Content ?? "No pude obtener una respuesta.";
    }
}

// Modelos para OpenAI
public class OpenAIResponse
{
    public Choice[] Choices { get; set; }
}

public class Choice
{
    public Message Message { get; set; }
}

public class Message
{
    public string Content { get; set; }
}
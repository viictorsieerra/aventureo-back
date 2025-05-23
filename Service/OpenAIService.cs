using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace TuProyecto.Services
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey; // Allow nullability with nullable reference type

        public OpenAIService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["OpenAI:ApiKey"] ?? throw new ArgumentNullException(nameof(configuration), "API key cannot be null."); // Ensure non-null assignment
        }

        // Renamed the duplicate method to avoid CS0111 error
        public async Task<string> GetChatResponseWithTourismContext(string message)
        {
            try
            {
                /*
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                var requestBody = new
                {
                    model = "gpt-4o",
                    messages = new[]
                    {
                            new { role = "system", content = "Eres un experto guía turístico de España." },
                            new { role = "user", content = message }
                        }
                };

                var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    return "Estoy recibiendo demasiadas peticiones ahora mismo. Inténtalo en unos segundos.";
                }

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                */
                string iaJsonFile = "ExampleIA.json";
                string responseString = File.ReadAllText(iaJsonFile);
                var jsonDoc = JsonDocument.Parse(responseString);

                if (!jsonDoc.RootElement.TryGetProperty("choices", out var choices))
                {
                    // Devuelve el error de OpenAI directamente o uno custom
                    if (jsonDoc.RootElement.TryGetProperty("error", out var error))
                    {
                        var errorMessage = error.GetProperty("message").GetString();
                        return $"Error de OpenAI: {errorMessage}";
                    }

                    return "Respuesta inesperada de la API.";
                }

                var reply = choices[0].GetProperty("message").GetProperty("content").GetString();
                return reply;
            }
            catch (Exception ex)
            {
                return $"Ha ocurrido un error: {ex.Message}";
            }
        }

        public async Task<string> GetChatResponse(string message)
        {
            try
                
            {
                /*
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    max_tokens = 15,  //  limite de la respuesta
                    messages = new[]

                                    {
                new { role = "system", content = "Eres un experto guía turístico de España." },
                new { role = "user", content = message }
            }
                };

                var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
                
                var responseString = await response.Content.ReadAsStringAsync();
                */
                string iaJsonFile = "ExampleIA.json";
                string responseString = File.ReadAllText(iaJsonFile);
             
                Console.WriteLine("Respuesta OpenAI:");
                Console.WriteLine(responseString); 

               /* if (!response.IsSuccessStatusCode)
                {
                    return $"Error de OpenAI: {response.StatusCode}\n{responseString}";
                }
               */
                var jsonDoc = JsonDocument.Parse(responseString);

                if (!jsonDoc.RootElement.TryGetProperty("choices", out var choices))
                {
                    if (jsonDoc.RootElement.TryGetProperty("error", out var error))
                    {
                        var errorMessage = error.GetProperty("message").GetString();
                        return $"Error de OpenAI: {errorMessage}";
                    }

                    return "Respuesta inesperada de la API.";
                }

                var reply = choices[0].GetProperty("message").GetProperty("content").GetString();
                return reply;
            }
            catch (Exception ex)
            {
                return $"Error en el servidor: {ex.Message}";
            }
        }


    }
}


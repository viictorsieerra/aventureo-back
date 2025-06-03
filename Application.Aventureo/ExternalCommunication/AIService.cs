using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.ExternalCommunication;
using Microsoft.Extensions.Configuration;

namespace Application.Aventureo.ExternalCommunication
{
    public class AIService : IAIService
    {
        private readonly IConfiguration _config;


        public AIService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> GetChatResponse(List<AIMessages> mensajes)
        {
            string apiKey = _config["OpenAI:ApiKey"];
            if (apiKey == null)
                throw new ArgumentNullException("No se ha encontrado la ApiKey de OpenAI");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                mensajes.Insert(0, new AIMessages
                {
                    role = "system",
                    content = "Eres un gran experto en turismo"
                });
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = mensajes
                };

                var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                var responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Respuesta OpenAI:");
                Console.WriteLine(responseString);

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error de OpenAI: {response.StatusCode}\n{responseString}");

                var jsonDoc = JsonDocument.Parse(responseString);

                if (!jsonDoc.RootElement.TryGetProperty("choices", out var choices))
                {
                    if (jsonDoc.RootElement.TryGetProperty("error", out var error))
                    {
                        var errorMessage = error.GetProperty("message").GetString();
                        throw new Exception($"Error de OpenAI: {errorMessage}");
                    }

                    throw new Exception("Respuesta inesperada de la API.");

                }

                var reply = choices[0].GetProperty("message").GetProperty("content").GetString();
                return reply;
            }
        }
    }
}


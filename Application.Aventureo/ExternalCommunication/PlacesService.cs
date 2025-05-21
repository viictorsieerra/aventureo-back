using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.ExternalCommunication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Aventureo.ExternalCommunication
{
    public class PlacesService : IPlacesService
    {
        private readonly IConfiguration? _configuration;

        public PlacesService(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ResultPlaces>> GetPlaces(QueryPlaces query)
        {
            string? url = _configuration["GOOGLE_PLACES:UrlApi"];
            string? apiKey = _configuration["GOOGLE_PLACES:ApiKey"];

            if (apiKey == null || apiKey == "" || url == null || url == "")
                throw new ArgumentNullException("URL O KEY DE GOOGLE PLACE NO ESTÁ RELLENADA");

            if (query == null)
                throw new ArgumentNullException("QUERY MAL RECIBIDA");

            using (HttpClient client = new HttpClient())
            {
                url+= $"json?location={query.location}&radius={query.radius}&type=lodging&key={apiKey}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                RootPlaces data = JsonConvert.DeserializeObject<RootPlaces>(responseBody);
                List<ResultPlaces> result = data.results;

                return result;

            }
        }
    }
}

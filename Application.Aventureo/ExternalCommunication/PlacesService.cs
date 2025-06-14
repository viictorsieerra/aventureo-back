﻿using Core.Aventureo.DTO;
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
                url += $"/nearbysearch/json?location={query.location}&radius={query.radius}&type=lodging&key={apiKey}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                RootPlaces data = JsonConvert.DeserializeObject<RootPlaces>(responseBody);
                List<ResultPlaces> result = data.results;

                return result;

            }

        }

        public async Task<InfoPlace> GetInfoPlace(string placeId)
        {
            string? url = _configuration["GOOGLE_PLACES:UrlApi"];
            string? apiKey = _configuration["GOOGLE_PLACES:ApiKey"];

            if (apiKey == null || apiKey == "" || url == null || url == "")
                throw new ArgumentNullException("URL O KEY DE GOOGLE PLACE NO ESTÁ RELLENADA");

            if (placeId == null)
                throw new ArgumentNullException("IDENTIFICADOR DEL ALOJAMIENTO MAL RECIBIDA");


            using (HttpClient client = new HttpClient())
            {
                url += $"/details/json?place_id={placeId}&fields=website,url,international_phone_number&key={apiKey}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                RootInfoPlace data = JsonConvert.DeserializeObject<RootInfoPlace>(responseBody);

                return data.result;
            }
        }
    }
}

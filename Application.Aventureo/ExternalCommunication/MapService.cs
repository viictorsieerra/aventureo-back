using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Interfaces.ExternalCommunication;
using Newtonsoft.Json;

namespace Application.Aventureo.ExternalCommunication
{
    public class MapService : IMapService
    {
        public async Task<MapDTO> GetInfoMapPlace(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("https://nominatim.openstreetmap.org/search?q={0}&format=json&addressdetails=1&limit=1", query);
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Aventureo/1.0 (aventureo@svalero.com)");

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                List<ResultMapDTO> resultQuery = JsonConvert.DeserializeObject<List<ResultMapDTO>>(responseBody);

                MapDTO result = new MapDTO
                {
                    lat = resultQuery[0].lat,
                    lon = resultQuery[0].lon,
                    name = resultQuery[0].address.city ?? resultQuery[0].address.village ?? resultQuery[0].address.town
                };

                return result;
            }
        }
    }
}

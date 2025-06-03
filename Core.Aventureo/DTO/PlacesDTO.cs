using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.DTO
{
    public record QueryPlaces
    {
        public string location { get; set; }
        public int radius { get; set; } = 5000; // En metros
    }
    public record ResultPlaces
    {
        public string name { get; set; }
        public string vicinity { get; set; }
        public double rating { get; set; }
        public int user_ratings_total { get; set; }
        public string place_id { get; set; }
    }

    public record RootPlaces
    {
        public List<ResultPlaces> results { get; set; }
        public string next_page_token { get; set; }
    }

    public record RootInfoPlace
    {
        public InfoPlace result { get; set; }
    }

    public record InfoPlace
    {
        public string international_phone_number { get; set; }
        public string url { get; set; }
        public string website { get; set; }
    }
}

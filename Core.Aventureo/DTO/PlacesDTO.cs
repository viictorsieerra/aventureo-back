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
        public GeometryPlaces geometry { get; set; }
        public string vicinity { get; set; }
        public double rating { get; set; }
        public int user_ratings_total { get; set; }
        public List<PhotoPlaces> photos { get; set; }
    }

    public record GeometryPlaces
    {
        public LocationPlaces location { get; set; }
    }
    public record LocationPlaces
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public record PhotoPlaces
    {
        public int height { get; set; }
        public int width { get; set; }
        public string photo_reference { get; set; }
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
        public string name { get; set; }
        public string url { get; set; }
        public string website { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.DTO
{
    public record ResultMapDTO
    {
        public string lat {  get; set; }
        public string lon { get; set; }
        public AdressMapDTO address { get; set; }
    }

    public record AdressMapDTO
    {
        public string? city { get; set; }
        public string? village { get; set; }
        public string? town { get; set; }
    }

    public record MapDTO
    {
        public string? lat { get; set; }
        public string? lon { get; set; }
        public string name { get; set; }
    }
}

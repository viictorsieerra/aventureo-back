using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace Aventureo_Back.Models
{
    public class ErrorDetail
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

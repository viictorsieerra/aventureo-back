using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.DTO
{
    public record UserMessage
    {
        public required string Message { get; set; }
    }
    public record AIMessages
    {
        public string? role { get; set; }
        public string? content { get; set; }
    }
}

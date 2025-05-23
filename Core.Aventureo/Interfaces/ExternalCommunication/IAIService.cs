using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.Interfaces.ExternalCommunication
{
    public interface IAIService
    {
        Task<string> GetChatResponseWithTourismContext(string message);
        Task<string> GetChatResponse(string message);
    }
}

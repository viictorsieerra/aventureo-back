using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;

namespace Core.Aventureo.Interfaces.ExternalCommunication
{
    public interface IAIService
    {
        Task<string> GetChatResponse(List<AIMessages> mensajes);
    }
}

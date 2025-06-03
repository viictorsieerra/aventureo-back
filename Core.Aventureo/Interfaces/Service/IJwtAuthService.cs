using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;

namespace Core.Aventureo.Interfaces.Service
{
    public interface IJwtAuthService
    {
        Task<TokenDto> GenerateTokenAsync(UserOutDTO user);
        Task<TokenDto> Login(LoginDTO login);
        Task<TokenDto> RegisterUser(RegisterUserDTO user);
    }
}

using Aventureo_Back.DTO;

namespace Aventureo_Back.Service.Interfaces
{
    public interface IJwtAuthService
    {
        Task<TokenDto> GenerateTokenAsync(UserOutDTO user);
        Task<TokenDto> Login(LoginDTO login);
        Task<TokenDto> RegisterUser(RegisterUserDTO user);
        Task<string> HashPassword(string password);
    }
}

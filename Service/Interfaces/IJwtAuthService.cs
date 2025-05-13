using Aventureo_Back.DTO;

namespace Aventureo_Back.Service.Interfaces
{
    public interface IJwtAuthService
    {
        Task<string> GenerateTokenAsync(UserOutDTO user);
        Task<string> Login(LoginDTO login);
        Task<string> RegisterUser(CreateUserDTO user);
        Task<string> HashPassword(string password);
    }
}

using Aventureo_Back.DTO;
using AventureoBack.Models;

namespace Aventureo_Back.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<UserOutDTO> GetUserFromCredentials(LoginDTO login);
        Task<UserOutDTO> RegisterUserFromCredentials(RegisterUserDTO userDTO);

    }
}

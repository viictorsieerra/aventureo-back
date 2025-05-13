using AventureoBack.Models;

namespace Aventureo_Back.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int idUsuario);
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario> UpdateAsync(Usuario usuario);
        Task DeleteAsync(int idUsuario);
    }
}

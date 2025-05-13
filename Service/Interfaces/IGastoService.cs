using AventureoBack.Models;

namespace Aventureo_Back.Service.Interfaces
{
    public interface IGastoService
    {
        Task<List<Gasto>> GetAllAsync();
        Task<Gasto> GetByIdAsync(int idGasto);
        Task<Gasto> AddAsync(Gasto gasto);
        Task<Gasto> UpdateAsync(Gasto gasto);
        Task DeleteAsync(int idGasto);
    }
}

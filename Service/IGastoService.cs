using AventureoBack.Models;

namespace AventureoBack.Services
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

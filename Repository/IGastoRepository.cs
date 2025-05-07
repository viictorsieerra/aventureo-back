using AventureoBack.Models;

namespace AventureoBack.Repositories
{
    public interface IGastoRepository
    {
        Task<List<Gasto>> GetAllAsync();
        Task<Gasto> GetByIdAsync(int idGasto);
        Task AddAsync(Gasto gasto);
        Task UpdateAsync(Gasto gasto);
        Task DeleteAsync(int idGasto);
    }
}

using AventureoBack.Models;

namespace AventureoBack.Repositories
{
    public interface IViajeRepository
    {
        Task<List<Viaje>> GetAllAsync();
        Task<Viaje> GetByIdAsync(int idViaje);
        Task AddAsync(Viaje viaje);
        Task UpdateAsync(Viaje viaje);
        Task DeleteAsync(int idViaje);
    }
}

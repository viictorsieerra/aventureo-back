using AventureoBack.Models;

namespace AventureoBack.Services
{
    public interface IViajeService
    {
        Task<List<Viaje>> GetAllAsync();
        Task<Viaje> GetByIdAsync(int idViaje);
        Task<Viaje> AddAsync(Viaje viaje);
        Task<Viaje> UpdateAsync(Viaje viaje);
        Task DeleteAsync(int idViaje);
    }
}

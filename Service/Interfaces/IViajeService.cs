using AventureoBack.Models;

namespace Aventureo_Back.Service.Interfaces
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

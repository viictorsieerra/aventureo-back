using Core.Aventureo.DTO;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Service
{
    public interface IViajeService
    {
        Task<List<Viaje>> GetAllAsync();
        Task<Viaje?> GetByIdAsync(int idViaje);
        Task<CreateViajeDTO> AddAsync(CreateViajeDTO ViajeDTO);
        Task<Viaje> UpdateAsync(UpdateViajeDTO ViajeDTO);
        Task DeleteAsync(int id);
    }
}

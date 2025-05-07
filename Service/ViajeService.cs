using AventureoBack.Models;
using AventureoBack.Repositories;

namespace AventureoBack.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _repository;

        public ViajeService(IViajeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Viaje>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Viaje> GetByIdAsync(int idViaje)
        {
            var viaje = await _repository.GetByIdAsync(idViaje);
            if (viaje == null)
            {
                throw new Exception("No se ha encontrado el viaje.");
            }
            return viaje;
        }

        public async Task<Viaje> AddAsync(Viaje viaje)
        {
            await _repository.AddAsync(viaje);
            return viaje;
        }

        public async Task<Viaje> UpdateAsync(Viaje updatedViaje)
        {
            var existingViaje = await _repository.GetByIdAsync(updatedViaje.idViaje);
            if (existingViaje == null)
            {
                throw new Exception("No se ha encontrado el viaje.");
            }

            existingViaje.idUsuario = updatedViaje.idUsuario;
            existingViaje.nombre = updatedViaje.nombre;
            existingViaje.cantidadTotal = updatedViaje.cantidadTotal;
            existingViaje.personas = updatedViaje.personas;

            await _repository.UpdateAsync(existingViaje);

            return existingViaje;
        }

        public async Task DeleteAsync(int idViaje)
        {
            await _repository.DeleteAsync(idViaje);
        }
    }
}

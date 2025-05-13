using Aventureo_Back.Repository.Interfaces;
using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using AventureoBack.Repositories;

namespace AventureoBack.Services
{
    public class GastoService : IGastoService
    {
        private readonly IGastoRepository _repository;

        public GastoService(IGastoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Gasto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Gasto> GetByIdAsync(int idGasto)
        {
            var gasto = await _repository.GetByIdAsync(idGasto);
            if (gasto == null)
            {
                throw new Exception("No se ha encontrado el gasto.");
            }
            return gasto;
        }

        public async Task<Gasto> AddAsync(Gasto gasto)
        {
            await _repository.CreateAsync(gasto);
            return gasto;
        }

        public async Task<Gasto> UpdateAsync(Gasto updatedGasto)
        {
            var existingGasto = await _repository.GetByIdAsync(updatedGasto.idGasto);
            if (existingGasto == null)
            {
                throw new Exception("No se ha encontrado el gasto.");
            }

            existingGasto.idViaje = updatedGasto.idViaje;
            existingGasto.idCategoria = updatedGasto.idCategoria;
            existingGasto.nombre = updatedGasto.nombre;
            existingGasto.cantidad = updatedGasto.cantidad;

            await _repository.UpdateAsync(existingGasto);

            return existingGasto;
        }

        public async Task DeleteAsync(int idGasto)
        {
            await _repository.DeleteAsync(idGasto);
        }
    }
}

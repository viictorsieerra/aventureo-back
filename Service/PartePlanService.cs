using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using AventureoBack.Repositories;

namespace AventureoBack.Services
{
    public class PartePlanService : IPartePlanService
    {
        private readonly IPartePlanRepository _repository;

        public PartePlanService(IPartePlanRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<PartePlan>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PartePlan> GetByIdAsync(int idPartePlan)
        {
            var partePlan = await _repository.GetByIdAsync(idPartePlan);
            if (partePlan == null)
            {
                throw new Exception("No se ha encontrado la parte del plan.");
            }
            return partePlan;
        }

        public async Task<PartePlan> AddAsync(PartePlan partePlan)
        {
            await _repository.AddAsync(partePlan);
            return partePlan;
        }

        public async Task<PartePlan> UpdateAsync(PartePlan updatedPartePlan)
        {
            var existingPartePlan = await _repository.GetByIdAsync(updatedPartePlan.idPartePlan);
            if (existingPartePlan == null)
            {
                throw new Exception("No se ha encontrado la parte del plan.");
            }

            existingPartePlan.idPlan = updatedPartePlan.idPlan;
            existingPartePlan.nombre = updatedPartePlan.nombre;
            existingPartePlan.ubicacion = updatedPartePlan.ubicacion;
            existingPartePlan.precio = updatedPartePlan.precio;
            existingPartePlan.comentario = updatedPartePlan.comentario;

            await _repository.UpdateAsync(existingPartePlan);

            return existingPartePlan;
        }

        public async Task DeleteAsync(int idPartePlan)
        {
            await _repository.DeleteAsync(idPartePlan);
        }
    }
}

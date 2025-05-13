using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using AventureoBack.Repositories;

namespace AventureoBack.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _repository;

        public PlanService(IPlanRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Plan>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Plan> GetByIdAsync(int idPlan)
        {
            var plan = await _repository.GetByIdAsync(idPlan);
            if (plan == null)
            {
                throw new Exception("No se ha encontrado el plan.");
            }
            return plan;
        }

        public async Task<Plan> AddAsync(Plan plan)
        {
            await _repository.AddAsync(plan);
            return plan;
        }

        public async Task<Plan> UpdateAsync(Plan updatedPlan)
        {
            var existingPlan = await _repository.GetByIdAsync(updatedPlan.idPlan);
            if (existingPlan == null)
            {
                throw new Exception("No se ha encontrado el plan.");
            }

            existingPlan.idUsuario = updatedPlan.idUsuario;
            existingPlan.lugar = updatedPlan.lugar;
            existingPlan.nombre = updatedPlan.nombre;
            existingPlan.duracion = updatedPlan.duracion;
            existingPlan.precioEstimado = updatedPlan.precioEstimado;
            existingPlan.valoracion = updatedPlan.valoracion;

            await _repository.UpdateAsync(existingPlan);

            return existingPlan;
        }

        public async Task DeleteAsync(int idPlan)
        {
            await _repository.DeleteAsync(idPlan);
        }
    }
}

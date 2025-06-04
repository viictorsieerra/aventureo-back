using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Core.Aventureo.Interfaces.Service;

namespace Application.Aventureo.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _repository;
        public PlanService (IPlanRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Plan>> GetAllAsync()
        {
            List<Plan> result = await _repository.GetAllAsync();

            return result;
        }
        public async Task<Plan?> GetByIdAsync(int idPlan)
        {
            Plan plan = await _repository.GetByIdAsync(idPlan);

            return plan;
        }
        public async Task<List<Plan>> GetPlansByLugar(string lugar)
        {
            List<Plan> result = await _repository.GetPlansByLugar(lugar);

            return result;
        }
        public async Task<CreatePlanDTO> AddAsync(CreatePlanDTO PlanDTO)
        {
            Plan plan = new Plan
            {
                idUsuario = PlanDTO.IdUsuario,
                lugar = PlanDTO.Lugar,
                nombre = PlanDTO.Nombre,
                duracion = PlanDTO.Duracion,
                precioEstimado = PlanDTO.PrecioEstimado,
                valoracion = PlanDTO.Valoracion
            };
            await _repository.AddAsync(plan);

            return PlanDTO;
        }
        public async Task<Plan> UpdateAsync(UpdatePlanDTO PlanDTO)
        {
            Plan existingPlan = await _repository.GetByIdAsync(PlanDTO.IdPlan);

            existingPlan.precioEstimado = PlanDTO.PrecioEstimado;
            existingPlan.valoracion = PlanDTO.Valoracion;
            existingPlan.duracion = PlanDTO.Duracion;
            existingPlan.lugar = PlanDTO.Lugar;
            existingPlan.nombre = PlanDTO.Nombre;

            await _repository.UpdateAsync(existingPlan);

            return existingPlan;
        }
        public async Task DeleteAsync(int id)
        {
            Plan plan = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(plan);
        }
    }
}

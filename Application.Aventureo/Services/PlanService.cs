using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository;
using Core.Aventureo.Interfaces.Service;

namespace Application.Aventureo.Services
{
    public class PlanService : IPlanService
    {
        private readonly IRepositoryBase<Plan> _repository;
        private readonly IRepositoryBase<PartePlan> _partePlanRepository;

        public PlanService(IRepositoryBase<Plan> repository, IRepositoryBase<PartePlan> partePlanRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _partePlanRepository = partePlanRepository ?? throw new ArgumentNullException(nameof(partePlanRepository));
        }


        public async Task<List<Plan>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Plan?> GetByIdAsync(int idPlan)
        {
            return await _repository.GetByIdAsync(idPlan);
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

            if (!string.IsNullOrWhiteSpace(PlanDTO.Comentario))
            {
                var partePlan = new PartePlan
                {
                    idPlan = plan.idPlan,
                    nombre = "Descripción",
                    ubicacion = PlanDTO.Lugar,
                    precio = 0,
                    comentario = PlanDTO.Comentario
                };
                await _partePlanRepository.AddAsync(partePlan);
            }

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

        public async Task<List<Plan>> GetByLugarAsync(string lugar)
        {
            var allPlans = await _repository.GetAllAsync();
            return allPlans
                .Where(p => p.lugar.Equals(lugar, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}

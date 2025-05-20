using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository;
using Core.Aventureo.Interfaces.Service;

namespace Application.Aventureo.Services
{
    public class PlanService : IPlanService
    {
        private readonly IRepositoryBase<Plan> _repository;
        public PlanService (IRepositoryBase<Plan> repository)
        {
            _repository = repository;
        }
        public async Task<List<Plan>> GetAllAsync();
        public async Task<Plan?> GetByIdAsync(int idPlan);
        public async Task<CreatePlanDTO> AddAsync(CreatePlanDTO PlanDTO);
        public async Task<Plan> UpdateAsync(UpdatePlanDTO PlanDTO);
        public async Task DeleteAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Service
{
    public interface IPlanService
    {
        Task<List<Plan>> GetAllAsync();
        Task<Plan?> GetByIdAsync(int idPlan);
        Task<CreatePlanDTO> AddAsync(CreatePlanDTO PlanDTO);
        Task<Plan> UpdateAsync(UpdatePlanDTO PlanDTO);
        Task<List<Plan>> GetByLugarAsync(string lugar);

        Task DeleteAsync(int id);
    }
}

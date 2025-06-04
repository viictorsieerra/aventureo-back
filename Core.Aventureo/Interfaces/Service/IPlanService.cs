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
        Task<List<Plan>> GetPlansByLugar(string lugar);
        Task<CreatePlanDTO> AddAsync(CreatePlanDTO PlanDTO);
        Task<Plan> UpdateAsync(UpdatePlanDTO PlanDTO);
        Task DeleteAsync(int id);
    }
}

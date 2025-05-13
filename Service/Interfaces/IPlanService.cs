using AventureoBack.Models;

namespace Aventureo_Back.Service.Interfaces
{
    public interface IPlanService
    {
        Task<List<Plan>> GetAllAsync();
        Task<Plan> GetByIdAsync(int idPlan);
        Task<Plan> AddAsync(Plan plan);
        Task<Plan> UpdateAsync(Plan plan);
        Task DeleteAsync(int idPlan);
    }
}

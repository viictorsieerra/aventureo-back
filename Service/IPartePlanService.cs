using AventureoBack.Models;

namespace AventureoBack.Services
{
    public interface IPartePlanService
    {
        Task<List<PartePlan>> GetAllAsync();
        Task<PartePlan> GetByIdAsync(int idPartePlan);
        Task<PartePlan> AddAsync(PartePlan partePlan);
        Task<PartePlan> UpdateAsync(PartePlan partePlan);
        Task DeleteAsync(int idPartePlan);
    }
}

using AventureoBack.Models;

namespace AventureoBack.Repositories
{
    public interface IPartePlanRepository
    {
        Task<List<PartePlan>> GetAllAsync();
        Task<PartePlan> GetByIdAsync(int idPartePlan);
        Task AddAsync(PartePlan partePlan);
        Task UpdateAsync(PartePlan partePlan);
        Task DeleteAsync(int idPartePlan);
    }
}

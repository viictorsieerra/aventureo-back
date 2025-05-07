using AventureoBack.Models;

namespace AventureoBack.Repositories
{
    public interface IPlanRepository
    {
        Task<List<Plan>> GetAllAsync();
        Task<Plan> GetByIdAsync(int idPlan);
        Task AddAsync(Plan plan);
        Task UpdateAsync(Plan plan);
        Task DeleteAsync(int idPlan);
    }
}

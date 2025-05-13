using System.Data;

namespace Aventureo_Back.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>>? GetAllAsync();
        Task<T>? GetByIdAsync(int id);
        Task<T>? CreateAsync(T entity);
        Task? UpdateAsync(T entity);
        Task? DeleteAsync(int id);
        
    }
}

using Core.Aventureo.Interfaces.Repository;
using Infraestructure.Aventureo.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Aventureo.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entity;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var result = await _entity.ToListAsync();
            if (result == null || !result.Any())
                throw new KeyNotFoundException($"No se encontraron registros de {typeof(T).Name}.");

            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _entity.FindAsync(id);
            if (result == null)
                throw new KeyNotFoundException($"{typeof(T).Name} con id {id} no encontrado.");

            return result;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

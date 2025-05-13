using AventureoBack.Models;
using AventureoBack.Data;
using Aventureo_Back.DTO;
using Aventureo_Back.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            var categorias = new List<Categoria>();

            categorias =await _context.Categorias.ToListAsync();

            return categorias;
        }

        public async Task<Categoria?> GetByIdAsync(int idCategoria)
        {
            Categoria? categoria = null;

            categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.IdCategoria == idCategoria);

            return categoria; 
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int idCategoria)
        {
            Categoria? categoria = await GetByIdAsync(idCategoria);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}

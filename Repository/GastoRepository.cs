using AventureoBack.Models;
using AventureoBack.Data;
using Aventureo_Back.DTO;
using Aventureo_Back.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly AppDbContext _context;

        public GastoRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Gasto>> GetAllAsync()
        {
            var gastos = new List<Gasto>();

            gastos = await _context.Gastos.ToListAsync();

            return gastos;
        }

        public async Task<Gasto?> GetByIdAsync(int idGasto)
        {
            Gasto? gasto = null;

            gasto = await _context.Gastos.FirstOrDefaultAsync(c => c.idGasto == idGasto);

            return gasto;
        }

        public async Task<Gasto> CreateAsync(Gasto gasto)
        {
            await _context.Gastos.AddAsync(gasto);
            await _context.SaveChangesAsync();
            return gasto;
        }

        public async Task UpdateAsync(Gasto gasto)
        {
            _context.Gastos.Update(gasto);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int idGasto)
        {
            Gasto? gasto = await GetByIdAsync(idGasto);
            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
        }
    }
}

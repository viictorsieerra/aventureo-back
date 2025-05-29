using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Context;
using Infraestructure.Aventureo.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Aventureo.Repository.Entities
{
    public class GastoRepository : RepositoryBase<Gasto>, IGastoRepository
    {
        private readonly AppDbContext _context;
        public GastoRepository (AppDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task <List<Gasto>> GetGastosByViaje (int id)
        {
            List<Gasto> gastos = await _context.Gastos.Where(g => g.idViaje == id).ToListAsync();

            if (gastos == null || !gastos.Any())
                throw new KeyNotFoundException("No se han encontrado gastos para este viaje");

            return gastos;
        }
    }
}

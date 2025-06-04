using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Context;
using Infraestructure.Aventureo.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aventureo.Repository.Entities
{
    public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
    {
        private readonly AppDbContext _context;

        public PlanRepository (AppDbContext context) : base (context)
        {
            _context = context;
        }

        public async Task <List<Plan>> GetPlansByLugar (string lugar)
        {
            List<Plan> result = await _context.Planes.Where(p => p.lugar == lugar).ToListAsync();

            if (result == null || !result.Any())
                throw new KeyNotFoundException("No se han encontrado planes para este lugar");

            return result;
        }
    }
}

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
    public class PartePlanRepository : RepositoryBase<PartePlan>, IPartePlanRepository
    {
        private readonly AppDbContext _context;
        public PartePlanRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PartePlan>> GetActividades(int idPlan)
        {
            List<PartePlan> result = await _context.PartesPlan.Where(p => p.idPlan == idPlan).ToListAsync();

            if (result == null || !result.Any())
                throw new KeyNotFoundException("No se han encontrado actividades para este plan");

            return result;
        }
    }
}

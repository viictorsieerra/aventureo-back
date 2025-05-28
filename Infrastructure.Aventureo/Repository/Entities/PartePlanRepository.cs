using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Context;
using Infraestructure.Aventureo.Repository;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Aventureo.Repository.Entities
{
    public class PartePlanRepository : RepositoryBase<PartePlan>,  IPartePlanRepository
    {
        private readonly AppDbContext _context;
        public PartePlanRepository(AppDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<PartePlan>> GetByPlan(int idPlan)
        {
            return await _context.PartesPlan.Where(pp => pp.idPlan == idPlan).ToListAsync();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Repository.Entities
{
    public interface IPartePlanRepository : IRepositoryBase<PartePlan>
    {
        Task<List<PartePlan>> GetActividades(int idPlan);
    }
}

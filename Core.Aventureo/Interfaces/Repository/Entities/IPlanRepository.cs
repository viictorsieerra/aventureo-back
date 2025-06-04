using Core.Aventureo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aventureo.Interfaces.Repository.Entities
{
    public interface IPlanRepository : IRepositoryBase<Plan>
    {
        Task<List<Plan>> GetPlansByLugar(string idLugar);
    }
}

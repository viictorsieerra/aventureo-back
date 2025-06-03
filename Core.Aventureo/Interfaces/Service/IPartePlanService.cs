using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Service
{
    public interface IPartePlanService
    {
        Task<List<PartePlan>> GetAllAsync();
        Task<PartePlan?> GetByIdAsync(int idPartePlan);
        Task<List<PartePlan>> GetActividades(int idPlan);
        Task<CreatePartePlanDTO> AddAsync(CreatePartePlanDTO PartePlanDTO);
        Task<PartePlan> UpdateAsync(UpdatePartePlanDTO PartePlanDTO);
        Task DeleteAsync(int id);
    }
}

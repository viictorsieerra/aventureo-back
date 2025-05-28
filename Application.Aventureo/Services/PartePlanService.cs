using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository;
using Core.Aventureo.Interfaces.Repository.Entities;
using Core.Aventureo.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aventureo.Services
{
    public class PartePlanService : IPartePlanService
    {
        private readonly IPartePlanRepository _repository;

        public PartePlanService(IPartePlanRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public async Task<List<PartePlan>> GetAllAsync()
        {
            List<PartePlan> result = await _repository.GetAllAsync();

            return result;
        }
        public async Task<PartePlan?> GetByIdAsync(int idPartePlan)
        {
            PartePlan partePlan = await _repository.GetByIdAsync(idPartePlan);
                
            return partePlan;
        }
        public async Task<CreatePartePlanDTO> AddAsync(CreatePartePlanDTO PartePlanDTO)
        {
            PartePlan partePlan = new PartePlan
            {
                idPlan = PartePlanDTO.idPlan,
                ubicacion = PartePlanDTO.ubicacion,
                nombre = PartePlanDTO.nombre,
                comentario = PartePlanDTO.comentario,
                precio = PartePlanDTO.precio
            };

            await _repository.AddAsync(partePlan);

            return PartePlanDTO;
        }
        public async Task<PartePlan> UpdateAsync(UpdatePartePlanDTO PartePlanDTO)
        {
            PartePlan existingPartePlan = await _repository.GetByIdAsync(PartePlanDTO.idPartePlan);

            existingPartePlan.ubicacion = PartePlanDTO.ubicacion;
            existingPartePlan.precio = PartePlanDTO.precio;
            existingPartePlan.comentario = PartePlanDTO.comentario;
            existingPartePlan.nombre = PartePlanDTO.nombre;

            await _repository.UpdateAsync(existingPartePlan);

            return existingPartePlan;
        }
        public async Task DeleteAsync(int id)
        {
            PartePlan partePlan = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(partePlan);
        }
        public async Task<List<PartePlan>> GetByPlan(int idPlan)
        {
            return await _repository.GetByPlan(idPlan);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository;
using Core.Aventureo.Interfaces.Service;

namespace Application.Aventureo.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IRepositoryBase<Viaje> _repository;

        public ViajeService(IRepositoryBase<Viaje> repository)
        {
            _repository = repository;
        }
        public async Task<List<Viaje>> GetAllAsync()
        {
            List<Viaje> result = await _repository.GetAllAsync();

            return result;
        }
        public async Task<Viaje?> GetByIdAsync(int idViaje)
        {
            Viaje viaje = await _repository.GetByIdAsync(idViaje);

            return viaje;
        }
        public async Task<CreateViajeDTO> AddAsync(CreateViajeDTO ViajeDTO)
        {
            Viaje viaje = new Viaje
            {
                idUsuario = ViajeDTO.IdUsuario,
                nombre = ViajeDTO.Nombre,
                cantidadTotal = ViajeDTO.CantidadTotal,
                personas = ViajeDTO.Personas
            };

            await _repository.AddAsync(viaje);

            return ViajeDTO;
        }
        public async Task<Viaje> UpdateAsync(UpdateViajeDTO ViajeDTO)
        {
            Viaje viaje = await _repository.GetByIdAsync(ViajeDTO.IdViaje);

            viaje.nombre = ViajeDTO.Nombre;
            viaje.cantidadTotal = ViajeDTO.CantidadTotal;
            viaje.personas = ViajeDTO.Personas;

            await _repository.UpdateAsync(viaje);

            return viaje;
        }
        public async Task DeleteAsync(int id)
        {
            Viaje viaje = await GetByIdAsync(id);
            await _repository.DeleteAsync(viaje);
        }
    }
}

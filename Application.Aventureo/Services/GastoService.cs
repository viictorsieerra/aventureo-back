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
    public class GastoService : IGastoService
    {
        private readonly IRepositoryBase<Gasto> _repository;
        public GastoService (IRepositoryBase<Gasto> repository)
        {
            _repository = repository;
        }
        public async Task<List<Gasto>> GetAllAsync()
        {
            List<Gasto> result = await _repository.GetAllAsync();

            if (result == null || !result.Any())
                throw new ArgumentNullException("No se han encontrado gastos");

            return result;
        }
       public async Task<Gasto?> GetByIdAsync(int idGasto)
        {
            Gasto? result = await _repository.GetByIdAsync(idGasto);

            if (result == null)
                throw new KeyNotFoundException("No se han encontrado gastos con este ID");

            return result;
        }
        public async Task<CreateGastoDTO> AddAsync(CreateGastoDTO gastoDTO)
        {
            Gasto gasto = new Gasto
            {
                idViaje = gastoDTO.idViaje,
                idCategoria = gastoDTO.idCategoria,
                nombre = gastoDTO.nombre,
                cantidad = gastoDTO.cantidad
            };

            await _repository.AddAsync(gasto);

            return gastoDTO;
        }
        public async Task<Gasto> UpdateAsync(UpdateGastoDTO gastoDTO)
        {
            Gasto gasto = await _repository.GetByIdAsync(gastoDTO.idGasto);

            gasto.idCategoria = gastoDTO.idCategoria;
            gasto.nombre = gastoDTO.nombre;
            gasto.cantidad = gastoDTO.cantidad;

            await _repository.UpdateAsync(gasto);

            return gasto;
        }
        public async Task DeleteAsync(int id)
        {
            Gasto gasto = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(gasto);
        }
    }
}

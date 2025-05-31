using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Service
{
    public interface IGastoService
    {
        Task<List<Gasto>> GetAllAsync();
        Task<Gasto?> GetByIdAsync(int idGasto);
        Task<List<GastoDTO>> GetGastosByViaje(int idViaje);
        Task<List<GastoCategoriaDTO>> GetGastosCategoryByViaje(int idViaje);
        Task<CreateGastoDTO> AddAsync(CreateGastoDTO gastoDTO);
        Task<Gasto> UpdateAsync(UpdateGastoDTO gastoDTO);
        Task DeleteAsync(int id);
    }
}

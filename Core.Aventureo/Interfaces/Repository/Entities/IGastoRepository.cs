using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Repository.Entities
{
    public interface IGastoRepository : IRepositoryBase<Gasto>
    {
        Task<List<GastoDTO>> GetGastosByViaje(int id);
        Task<List<GastoCategoriaDTO>> GetGastosCategoryByViaje(int idViaje);
    }
}

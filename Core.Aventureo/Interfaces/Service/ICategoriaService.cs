using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Service
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int idCategoria);
        Task<CreateCategoriaDTO> AddAsync(CreateCategoriaDTO categoriaDTO);
        Task<Categoria> UpdateAsync(UpdateCategoriaDTO categoriaDTO);
        Task DeleteAsync(int id);
    }
}

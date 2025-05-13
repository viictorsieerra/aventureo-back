using Aventureo_Back.DTO;
using AventureoBack.Models;

namespace Aventureo_Back.Service.Interfaces;


public interface ICategoriaService
{
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(int idCategoria);
    Task <CreateCategoriaDTO>AddAsync(CreateCategoriaDTO categoriaDTO);
    Task <Categoria>UpdateAsync(UpdateCategoriaDTO categoriaDTO);
    Task DeleteAsync(int id);
}
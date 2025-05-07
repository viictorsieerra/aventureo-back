using AventureoBack.Models;
using AventureoBack.Models;
namespace Repositories;

interface ICategoriaRepository
{
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(int id);
    Task AddAsync(Categoria categoria);
    Task UpdateAsync(Categoria categoria);
    Task DeleteAsync(int id);
    Task InicializarDatosAsync();
    Task<Categoria> GetByIdAsync(object idCategoria);
}
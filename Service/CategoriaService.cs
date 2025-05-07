using AventureoBack.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

      
        public async Task<List<Categoria>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las categorías: {ex.Message}");
            }
        }

  
        public async Task<Categoria> GetByIdAsync(int idCategoria)
        {
            try
            {
                var categoria = await _repository.GetByIdAsync(idCategoria);
                if (categoria == null)
                {
                    throw new Exception("Categoría no encontrada.");
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la categoría: {ex.Message}");
            }
        }

       
        public async Task<Categoria> AddAsync(Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    throw new ArgumentNullException(nameof(categoria), "La categoría no puede ser nula.");
                }

                var createdCategoria = await _repository.AddAsync(categoria);
                return createdCategoria;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar la categoría: {ex.Message}");
            }
        }

        
        public async Task<Categoria> UpdateAsync(Categoria updatedCategoria)
        {
            try
            {
                if (updatedCategoria == null)
                {
                    throw new ArgumentNullException(nameof(updatedCategoria), "La categoría a actualizar no puede ser nula.");
                }

                var existingCategoria = await _repository.GetByIdAsync(updatedCategoria.idCategoria);
                if (existingCategoria == null)
                {
                    throw new Exception("Categoría no encontrada.");
                }

                
                existingCategoria.Nombre = updatedCategoria.Nombre;
                existingCategoria.Descripcion = updatedCategoria.Descripcion;

                var updated = await _repository.UpdateAsync(existingCategoria);
                return updated;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la categoría: {ex.Message}");
            }
        }

        public async Task DeleteAsync(int idCategoria)
        {
            try
            {
                var categoria = await _repository.GetByIdAsync(idCategoria);
                if (categoria == null)
                {
                    throw new Exception("Categoría no encontrada.");
                }

                await _repository.DeleteAsync(idCategoria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la categoría: {ex.Message}");
            }
        }

      
        public async Task InicializarDatosAsync()
        {
            try
            {
                await _repository.InicializarDatosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al inicializar los datos: {ex.Message}");
            }
        }
    }
}

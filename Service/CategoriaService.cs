using Aventureo_Back.DTO;
using Aventureo_Back.Repository.Interfaces;
using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            List<Categoria> categorias = await _repository.GetAllAsync();
            return categorias;
        }

        public async Task<Categoria> GetByIdAsync(int idCategoria)
        {
            Categoria? categoria = await _repository.GetByIdAsync(idCategoria);
            if (categoria == null)
            {
                throw new Exception("No se han encontrado datos");
            }
            return categoria;
        }


        public async Task<CreateCategoriaDTO> AddAsync(CreateCategoriaDTO categoria)
        {
            Categoria newCategoria = new Categoria { Nombre = categoria.Nombre, Descripcion = categoria.Descripcion };
            await _repository.AddAsync(newCategoria);
            return categoria;
        }


        public async Task<Categoria> UpdateAsync(UpdateCategoriaDTO updatedCategoria)
        {
            Categoria? existingCategoria = await _repository.GetByIdAsync(updatedCategoria.IdCategoria);

            if (existingCategoria == null)
                throw new Exception("Categoría no encontrada");

            existingCategoria.Nombre = updatedCategoria.Nombre;
            existingCategoria.Descripcion = updatedCategoria.Descripcion;

            await _repository.UpdateAsync(existingCategoria);
            return existingCategoria;
        }



        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

        }


    }
}

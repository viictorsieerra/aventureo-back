using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.Dto;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository;
using Core.Aventureo.Interfaces.Service;

namespace Application.Aventureo.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepositoryBase<Categoria> _repository;

        public CategoriaService(IRepositoryBase<Categoria> repository)
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

            existingCategoria.Nombre = updatedCategoria.Nombre;
            existingCategoria.Descripcion = updatedCategoria.Descripcion;

            await _repository.UpdateAsync(existingCategoria);
            return existingCategoria;
        }



        public async Task DeleteAsync(int id)
        {
            Categoria categoria = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(categoria);

        }
    }
}

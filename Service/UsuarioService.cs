using Aventureo_Back.Repository.Interfaces;
using Aventureo_Back.Service.Interfaces;
using AventureoBack.Models;

namespace AventureoBack.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(int idUsuario)
        {
            var usuario = await _repository.GetByIdAsync(idUsuario);
            if (usuario == null)
            {
                throw new Exception("No se ha encontrado el usuario.");
            }
            return usuario;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _repository.AddAsync(usuario);
            return usuario;
        }

        public async Task<Usuario> UpdateAsync(Usuario updatedUsuario)
        {
            var existingUsuario = await _repository.GetByIdAsync(updatedUsuario.idUsuario);
            if (existingUsuario == null)
            {
                throw new Exception("No se ha encontrado el usuario.");
            }

            existingUsuario.nombre = updatedUsuario.nombre;
            existingUsuario.apellidos = updatedUsuario.apellidos;
            existingUsuario.fecNacimiento = updatedUsuario.fecNacimiento;
            existingUsuario.email = updatedUsuario.email;
            existingUsuario.contrasena = updatedUsuario.contrasena;

            await _repository.UpdateAsync(existingUsuario);

            return existingUsuario;
        }

        public async Task DeleteAsync(int idUsuario)
        {
            await _repository.DeleteAsync(idUsuario);
        }
    }
}

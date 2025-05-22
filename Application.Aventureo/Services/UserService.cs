using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Core.Aventureo.Interfaces.Service;

namespace Application.Aventureo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Usuario>> GetAllAsync()
        {
            List<Usuario> result = await _repository.GetAllAsync();

            return result;
        }
        public async Task<Usuario?> GetByIdAsync(int idUsuario)
        {
            Usuario user = await _repository.GetByIdAsync(idUsuario);

            return user;
        }

        public async Task<Usuario?> GetByToken(ClaimsPrincipal claimUser)
        {
            var id = claimUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (id == null)
                throw new Exception("NO SE ENCUENTRA EL ID DEL USUARIO A TRAVÉS DEL TOKEN");

            int idUsuario;

            if (!int.TryParse(id.Value, out idUsuario))
                throw new Exception("Fallo al cambiar la ID");

            Usuario? user = await _repository.GetByIdAsync(idUsuario);

            return user;

        }

        public async Task<AddModUserDTO> AddAsync(AddModUserDTO UsuarioDTO)
        {
            Usuario user = new Usuario
            {
                nombre = UsuarioDTO.Nombre,
                apellidos = UsuarioDTO.Apellidos,
                fecNacimiento = UsuarioDTO.FecNacimiento,
                email = UsuarioDTO.Email,
                contrasena = UsuarioDTO.Contrasena,
                RolAdmin = UsuarioDTO.RolAdmin
            };

            await _repository.AddAsync(user);

            return UsuarioDTO;
        }
        public async Task<Usuario> UpdateAsync(AddModUserDTO UsuarioDTO)
        {
            Usuario existingUser = await _repository.GetByIdAsync(UsuarioDTO.IdUsuario);

            existingUser.nombre = UsuarioDTO.Nombre;
            existingUser.apellidos = UsuarioDTO.Apellidos;
            existingUser.fecNacimiento = UsuarioDTO.FecNacimiento;
            existingUser.email = UsuarioDTO.Email;
            existingUser.contrasena = UsuarioDTO.Contrasena;
            existingUser.RolAdmin = UsuarioDTO.RolAdmin;

            await _repository.UpdateAsync(existingUser);

            return existingUser;
        }
        public async Task DeleteAsync(int id)
        {
            Usuario user = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(user);
        }
    }
}

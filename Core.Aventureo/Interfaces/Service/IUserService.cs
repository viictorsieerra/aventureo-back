using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.Dto;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Service
{
    public interface IUserService
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int idUsuario);
        Task<AddModUserDTO> AddAsync(AddModUserDTO UsuarioDTO);
        Task<Usuario> UpdateAsync(AddModUserDTO UsuarioDTO);
        Task DeleteAsync(int id);
    }
}

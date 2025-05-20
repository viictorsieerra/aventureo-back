using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;

namespace Core.Aventureo.Interfaces.Repository.Entities
{
    public interface IUserRepository : IRepositoryBase<Usuario>
    {
            Task<UserOutDTO> GetUserFromCredentials(LoginDTO login);
            Task<UserOutDTO> RegisterUserFromCredentials(RegisterUserDTO userDTO);

    }
}

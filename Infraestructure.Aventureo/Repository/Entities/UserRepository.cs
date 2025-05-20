using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Aventureo.Repository.Entities
{
    public class UserRepository : RepositoryBase<Usuario> ,IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<UserOutDTO> GetUserFromCredentials(LoginDTO login)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(us => us.email == login.Email);

            if (user == null)
                throw new KeyNotFoundException("NO SE HA ENCONTRADO UN USUARIO REGISTRADO CON ESTE CORREO");

            if (login.Contrasena != user.contrasena)
                throw new UnauthorizedAccessException("CONTRASEÑA INCORRECTA");
          
            return new UserOutDTO { Email = login.Email, IdUsuario = user.idUsuario };
        }

        public async Task<UserOutDTO> RegisterUserFromCredentials(RegisterUserDTO userDTO)
        {
            Usuario user = new Usuario
            {
                nombre = userDTO.Nombre,
                apellidos = userDTO.Apellidos,
                email = userDTO.Email,
                contrasena = userDTO.Contrasena,
                fecNacimiento = userDTO.FecNacimiento

            };
            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();

            UserOutDTO? userOut = await _context.Usuarios
                .Select(u =>
                new UserOutDTO
                {
                    IdUsuario = u.idUsuario,
                    Email = u.email,
                    RolAdmin = u.RolAdmin
                }).Where(u => u.Email == user.email).FirstOrDefaultAsync();

            return userOut;
        }
    }
}

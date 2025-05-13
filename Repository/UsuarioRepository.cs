using AventureoBack.Models;
using AventureoBack.Data;
using Aventureo_Back.DTO;
using Aventureo_Back.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            var Usuarios = new List<Usuario>();

            Usuarios = await _context.Usuarios.ToListAsync();

            return Usuarios;
        }

        public async Task<Usuario?> GetByIdAsync(int idUsuario)
        {
            Usuario? Usuario = null;

            Usuario = await _context.Usuarios.FirstOrDefaultAsync(c => c.idUsuario == idUsuario);

            return Usuario;
        }

        public async Task<Usuario> CreateAsync(Usuario Usuario)
        {
            await _context.Usuarios.AddAsync(Usuario);
            await _context.SaveChangesAsync();
            return Usuario;
        }

        public async Task UpdateAsync(Usuario Usuario)
        {
            _context.Usuarios.Update(Usuario);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int idUsuario)
        {
            Usuario? Usuario = await GetByIdAsync(idUsuario);
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<UserOutDTO> GetUserFromCredentials(LoginDTO login)
        {

            var user = await _context.Usuarios.FirstOrDefaultAsync(us => us.email == login.Email);

            if (user == null) throw new KeyNotFoundException("NO SE HA ENCONTRADO UN USUARIO REGISTRADO CON ESTE CORREO");

            if(login.Contrasena != user.contrasena)
            {
                throw new KeyNotFoundException("CONTRASEÑA INCORRECTA");
            }
            return new UserOutDTO { Email = login.Email, IdUsuario = user.idUsuario };
        }
    }
}

using AventureoBack.Models;
using Microsoft.Data.SqlClient;

namespace AventureoBack.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string? _connectionString;

        public UsuarioRepository(string? connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT idUsuario, nombre, apellidos, fecNacimiento, email, contrasena FROM Usuario";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var usuario = new Usuario
                        {
                            idUsuario = reader.GetInt32(0),
                            nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            apellidos = reader.IsDBNull(2) ? null : reader.GetString(2),
                            fecNacimiento = reader.GetDateTime(3),
                            email = reader.IsDBNull(4) ? null : reader.GetString(4),
                            contrasena = reader.IsDBNull(5) ? null : reader.GetString(5)
                        };

                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }

       public async Task<Usuario> GetByIdAsync(int idUsuario)
{
    Usuario? usuario = null;

    using (var connection = new SqlConnection(_connectionString))
    {
        await connection.OpenAsync();
        var query = "SELECT idUsuario, nombre, apellidos, fecNacimiento, email, contrasena FROM Usuario WHERE idUsuario = @idUsuario";

        using (var command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@idUsuario", idUsuario);

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    usuario = new Usuario
                    {
                        idUsuario = reader.GetInt32(0),
                        nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                        apellidos = reader.IsDBNull(2) ? null : reader.GetString(2),
                        fecNacimiento = reader.GetDateTime(3),
                        email = reader.IsDBNull(4) ? null : reader.GetString(4),
                        contrasena = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                }
            }
        }
    }

    if (usuario == null)
    {
        throw new KeyNotFoundException($"No se encontró un Usuario con el id {idUsuario}.");
    }

    return usuario;
}
        public async Task AddAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Usuario (nombre, apellidos, fecNacimiento, email, contrasena) VALUES (@nombre, @apellidos, @fecNacimiento, @email, @contrasena)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", (object?)usuario.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@apellidos", (object?)usuario.apellidos ?? DBNull.Value);
                    command.Parameters.AddWithValue("@fecNacimiento", usuario.fecNacimiento);
                    command.Parameters.AddWithValue("@email", (object?)usuario.email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@contrasena", (object?)usuario.contrasena ?? DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE Usuario SET nombre = @nombre, apellidos = @apellidos, fecNacimiento = @fecNacimiento, email = @email, contrasena = @contrasena WHERE idUsuario = @idUsuario";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", (object?)usuario.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@apellidos", (object?)usuario.apellidos ?? DBNull.Value);
                    command.Parameters.AddWithValue("@fecNacimiento", usuario.fecNacimiento);
                    command.Parameters.AddWithValue("@email", (object?)usuario.email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@contrasena", (object?)usuario.contrasena ?? DBNull.Value);
                    command.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int idUsuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Usuario WHERE idUsuario = @idUsuario";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

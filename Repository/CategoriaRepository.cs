using Microsoft.Data.SqlClient;
using AventureoBack.Models;

namespace Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString;

        public CategoriaRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            var categorias = new List<Categoria>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT idCategoria, Nombre, Descripcion FROM Categoria";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var categoria = new Categoria
                        {
                            IdCategoria = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.GetString(2)
                        };

                        categorias.Add(categoria);
                    }
                }
            }

            return categorias;
        }

        public async Task<Categoria?> GetByIdAsync(int idCategoria)
        {
            Categoria? categoria = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT idCategoria, Nombre, Descripcion FROM Categoria WHERE idCategoria = @idCategoria";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCategoria", idCategoria);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            categoria = new Categoria
                            {
                                IdCategoria = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2)
                            };
                        }
                    }
                }
            }

            return categoria; 
        }

        public async Task AddAsync(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Categoria (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Categoria SET Nombre = @Nombre, Descripcion = @Descripcion WHERE idCategoria = @idCategoria";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                    command.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int idCategoria)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Categoria WHERE idCategoria = @idCategoria";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCategoria", idCategoria);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task InicializarDatosAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    INSERT INTO Categoria (Nombre, Descripcion) VALUES
                    ('Alimentación', 'Gastos en comida y supermercado'),
                    ('Transporte', 'Gastos en transporte público y combustible'),
                    ('Ocio', 'Gastos en entretenimiento y recreación');";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<Categoria> GetByIdAsync(object idCategoria)
        {
            throw new NotImplementedException();
        }
    }
}

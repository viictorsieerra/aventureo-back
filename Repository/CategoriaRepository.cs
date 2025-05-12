using Microsoft.Data.SqlClient;
using AventureoBack.Models;
using AventureoBack.Data;

namespace Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            var categorias = new List<Categoria>();

            categorias = _context.Categorias.ToList();

            return categorias;
        }

        public async Task<Categoria?> GetByIdAsync(int idCategoria)
        {
            Categoria? categoria = null;

            categoria = _context.Categorias.FirstOrDefault(c => c.IdCategoria == idCategoria);

            return categoria; 
        }

        public async Task AddAsync(Categoria categoria)
        {
            _context.AddAsync(categoria);
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            /*
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
            }*/
        }

        public async Task DeleteAsync(int idCategoria)
        {/*
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Categoria WHERE idCategoria = @idCategoria";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCategoria", idCategoria);

                    await command.ExecuteNonQueryAsync();
                }
            }*/
        }
    }
}

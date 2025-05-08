using AventureoBack.Models;
using Microsoft.Data.SqlClient;

namespace AventureoBack.Repositories
{
    public class PartePlanRepository : IPartePlanRepository
    {
        private readonly string? _connectionString;

        public PartePlanRepository(string? connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<PartePlan>> GetAllAsync()
        {
            var partesPlan = new List<PartePlan>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT idPartePlan, idPlan, nombre, ubicacion, precio, comentario FROM PartePlan";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var partePlan = new PartePlan
                        {
                            idPartePlan = reader.GetInt32(0),
                            idPlan = reader.GetInt32(1),
                            nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                            ubicacion = reader.IsDBNull(3) ? null : reader.GetString(3),
                            precio = reader.GetDecimal(4),
                            comentario = reader.IsDBNull(5) ? null : reader.GetString(5)
                        };

                        partesPlan.Add(partePlan);
                    }
                }
            }

            return partesPlan;
        }

      public async Task<PartePlan> GetByIdAsync(int idPartePlan)
{
    PartePlan? partePlan = null;

    using (var connection = new SqlConnection(_connectionString))
    {
        await connection.OpenAsync();

        var query = "SELECT idPartePlan, idPlan, nombre, ubicacion, precio, comentario FROM PartePlan WHERE idPartePlan = @idPartePlan";

        using (var command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@idPartePlan", idPartePlan);

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    partePlan = new PartePlan
                    {
                        idPartePlan = reader.GetInt32(0),
                        idPlan = reader.GetInt32(1),
                        nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                        ubicacion = reader.IsDBNull(3) ? null : reader.GetString(3),
                        precio = reader.GetDecimal(4),
                        comentario = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                }
            }
        }
    }

    if (partePlan == null)
    {
        throw new KeyNotFoundException($"No se encontró un PartePlan con el id {idPartePlan}.");
    }

    return partePlan;
}
        public async Task AddAsync(PartePlan partePlan)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO PartePlan (idPlan, nombre, ubicacion, precio, comentario) VALUES (@idPlan, @nombre, @ubicacion, @precio, @comentario)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlan", partePlan.idPlan);
                    command.Parameters.AddWithValue("@nombre", (object?)partePlan.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ubicacion", (object?)partePlan.ubicacion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@precio", partePlan.precio);
                    command.Parameters.AddWithValue("@comentario", (object?)partePlan.comentario ?? DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(PartePlan partePlan)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE PartePlan SET idPlan = @idPlan, nombre = @nombre, ubicacion = @ubicacion, precio = @precio, comentario = @comentario WHERE idPartePlan = @idPartePlan";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlan", partePlan.idPlan);
                    command.Parameters.AddWithValue("@nombre", (object?)partePlan.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ubicacion", (object?)partePlan.ubicacion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@precio", partePlan.precio);
                    command.Parameters.AddWithValue("@comentario", (object?)partePlan.comentario ?? DBNull.Value);
                    command.Parameters.AddWithValue("@idPartePlan", partePlan.idPartePlan);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int idPartePlan)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM PartePlan WHERE idPartePlan = @idPartePlan";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPartePlan", idPartePlan);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

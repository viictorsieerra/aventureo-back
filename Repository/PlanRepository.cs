using AventureoBack.Models;
using Microsoft.Data.SqlClient;

namespace AventureoBack.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly string? _connectionString;

        public PlanRepository(string? connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Plan>> GetAllAsync()
        {
            var planes = new List<Plan>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT idPlan, idUsuario, lugar, nombre, duracion, precioEstimado, valoracion FROM Plan";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var plan = new Plan
                        {
                            idPlan = reader.GetInt32(0),
                            idUsuario = reader.GetInt32(1),
                            lugar = reader.IsDBNull(2) ? null : reader.GetString(2),
                            nombre = reader.IsDBNull(3) ? null : reader.GetString(3),
                            duracion = reader.GetInt32(4),
                            precioEstimado = reader.GetDecimal(5),
                            valoracion = reader.GetInt32(6)
                        };

                        planes.Add(plan);
                    }
                }
            }

            return planes;
        }

        public async Task<Plan> GetByIdAsync(int idPlan)
        {
            Plan plan = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT idPlan, idUsuario, lugar, nombre, duracion, precioEstimado, valoracion FROM Plan WHERE idPlan = @idPlan";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlan", idPlan);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            plan = new Plan
                            {
                                idPlan = reader.GetInt32(0),
                                idUsuario = reader.GetInt32(1),
                                lugar = reader.IsDBNull(2) ? null : reader.GetString(2),
                                nombre = reader.IsDBNull(3) ? null : reader.GetString(3),
                                duracion = reader.GetInt32(4),
                                precioEstimado = reader.GetDecimal(5),
                                valoracion = reader.GetInt32(6)
                            };
                        }
                    }
                }
            }

            return plan;
        }

        public async Task AddAsync(Plan plan)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Plan (idUsuario, lugar, nombre, duracion, precioEstimado, valoracion) VALUES (@idUsuario, @lugar, @nombre, @duracion, @precioEstimado, @valoracion)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", plan.idUsuario);
                    command.Parameters.AddWithValue("@lugar", (object?)plan.lugar ?? DBNull.Value);
                    command.Parameters.AddWithValue("@nombre", (object?)plan.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@duracion", plan.duracion);
                    command.Parameters.AddWithValue("@precioEstimado", plan.precioEstimado);
                    command.Parameters.AddWithValue("@valoracion", plan.valoracion);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Plan plan)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE Plan SET idUsuario = @idUsuario, lugar = @lugar, nombre = @nombre, duracion = @duracion, precioEstimado = @precioEstimado, valoracion = @valoracion WHERE idPlan = @idPlan";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", plan.idUsuario);
                    command.Parameters.AddWithValue("@lugar", (object?)plan.lugar ?? DBNull.Value);
                    command.Parameters.AddWithValue("@nombre", (object?)plan.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@duracion", plan.duracion);
                    command.Parameters.AddWithValue("@precioEstimado", plan.precioEstimado);
                    command.Parameters.AddWithValue("@valoracion", plan.valoracion);
                    command.Parameters.AddWithValue("@idPlan", plan.idPlan);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int idPlan)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM Plan WHERE idPlan = @idPlan";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlan", idPlan);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

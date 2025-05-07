using AventureoBack.Models;
using Microsoft.Data.SqlClient;

namespace AventureoBack.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly string? _connectionString;

        public GastoRepository(string? connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Gasto>> GetAllAsync()
        {
            var gastos = new List<Gasto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT idGasto, idViaje, idCategoria, nombre, cantidad FROM Gasto";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var gasto = new Gasto
                        {
                            idGasto = reader.GetInt32(0),
                            idViaje = reader.GetInt32(1),
                            idCategoria = reader.GetInt32(2),
                            nombre = reader.IsDBNull(3) ? null : reader.GetString(3),
                            cantidad = reader.GetDecimal(4)
                        };

                        gastos.Add(gasto);
                    }
                }
            }

            return gastos;
        }

        public async Task<Gasto> GetByIdAsync(int idGasto)
        {
            Gasto gasto = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT idGasto, idViaje, idCategoria, nombre, cantidad FROM Gasto WHERE idGasto = @idGasto";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idGasto", idGasto);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            gasto = new Gasto
                            {
                                idGasto = reader.GetInt32(0),
                                idViaje = reader.GetInt32(1),
                                idCategoria = reader.GetInt32(2),
                                nombre = reader.IsDBNull(3) ? null : reader.GetString(3),
                                cantidad = reader.GetDecimal(4)
                            };
                        }
                    }
                }
            }

            return gasto;
        }

        public async Task AddAsync(Gasto gasto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Gasto (idViaje, idCategoria, nombre, cantidad) VALUES (@idViaje, @idCategoria, @nombre, @cantidad)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idViaje", gasto.idViaje);
                    command.Parameters.AddWithValue("@idCategoria", gasto.idCategoria);
                    command.Parameters.AddWithValue("@nombre", (object?)gasto.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@cantidad", gasto.cantidad);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Gasto gasto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE Gasto SET idViaje = @idViaje, idCategoria = @idCategoria, nombre = @nombre, cantidad = @cantidad WHERE idGasto = @idGasto";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idViaje", gasto.idViaje);
                    command.Parameters.AddWithValue("@idCategoria", gasto.idCategoria);
                    command.Parameters.AddWithValue("@nombre", (object?)gasto.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@cantidad", gasto.cantidad);
                    command.Parameters.AddWithValue("@idGasto", gasto.idGasto);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int idGasto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM Gasto WHERE idGasto = @idGasto";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idGasto", idGasto);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

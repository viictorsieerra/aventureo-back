using AventureoBack.Models;
using Microsoft.Data.SqlClient;

namespace AventureoBack.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly string? _connectionString;

        public ViajeRepository(string? connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Viaje>> GetAllAsync()
        {
            var viajes = new List<Viaje>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT idViaje, idUsuario, nombre, cantidadTotal, personas FROM Viaje";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var viaje = new Viaje
                        {
                            idViaje = reader.GetInt32(0),
                            idUsuario = reader.GetInt32(1),
                            nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                            cantidadTotal = reader.GetDecimal(3),
                            personas = reader.GetInt32(4)
                        };

                        viajes.Add(viaje);
                    }
                }
            }

            return viajes;
        }

        public async Task<Viaje> GetByIdAsync(int idViaje)
        {
            Viaje viaje = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT idViaje, idUsuario, nombre, cantidadTotal, personas FROM Viaje WHERE idViaje = @idViaje";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idViaje", idViaje);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            viaje = new Viaje
                            {
                                idViaje = reader.GetInt32(0),
                                idUsuario = reader.GetInt32(1),
                                nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                                cantidadTotal = reader.GetDecimal(3),
                                personas = reader.GetInt32(4)
                            };
                        }
                    }
                }
            }

            return viaje;
        }

        public async Task AddAsync(Viaje viaje)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO Viaje (idUsuario, nombre, cantidadTotal, personas) VALUES (@idUsuario, @nombre, @cantidadTotal, @personas)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", viaje.idUsuario);
                    command.Parameters.AddWithValue("@nombre", (object?)viaje.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@cantidadTotal", viaje.cantidadTotal);
                    command.Parameters.AddWithValue("@personas", viaje.personas);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Viaje viaje)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE Viaje SET idUsuario = @idUsuario, nombre = @nombre, cantidadTotal = @cantidadTotal, personas = @personas WHERE idViaje = @idViaje";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", viaje.idUsuario);
                    command.Parameters.AddWithValue("@nombre", (object?)viaje.nombre ?? DBNull.Value);
                    command.Parameters.AddWithValue("@cantidadTotal", viaje.cantidadTotal);
                    command.Parameters.AddWithValue("@personas", viaje.personas);
                    command.Parameters.AddWithValue("@idViaje", viaje.idViaje);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int idViaje)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Viaje WHERE idViaje = @idViaje";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idViaje", idViaje);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

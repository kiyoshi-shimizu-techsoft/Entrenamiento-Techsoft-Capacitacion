using Bisoft.Entrenamiento.Dominio.Entities;
using Bisoft.Entrenamiento.Dominio.Repositories;
using Microsoft.Data.SqlClient;

namespace Bisoft.Entrenamiento.Infraestructura.Repositories;
public class PacienteMsSqlServerRepository : IPacienteRepository
{
    private readonly string _connectionString = "Server=LAP-KIYOSHI;Initial Catalog=EjemploBD; Trusted_Connection=True; Encrypt=false; TrustServerCertificate=True";

    public async Task AgregarPaciente(Paciente paciente)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand(
                "INSERT INTO Pacientes (Id, Nombre, Telefono, Email) VALUES (@Id, @Nombre, @Telefono, @Email)",
                connection);
            command.Parameters.AddWithValue("@Id", paciente.Id);
            command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
            command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
            command.Parameters.AddWithValue("@Email", paciente.Email);
            await command.ExecuteNonQueryAsync();
        }
    }

    public Task GuardarCambios()
    {
        return Task.CompletedTask;
    }

    public Task<Paciente> ObtenerPacientePorId(Guid id)
    {
        throw new NotImplementedException();
    }
}

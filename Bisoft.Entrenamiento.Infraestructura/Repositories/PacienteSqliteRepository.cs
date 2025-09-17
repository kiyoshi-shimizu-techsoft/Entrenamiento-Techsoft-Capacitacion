using Bisoft.Entrenamiento.Dominio.Entities;
using Bisoft.Entrenamiento.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisoft.Entrenamiento.Infraestructura.Repositories;
public class PacienteSqliteRepository : IPacienteRepository
{
    public Task AgregarPaciente(Paciente paciente)
    {
        var connectionString = "Data Source=pacientes.db";
        using var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Pacientes (Id, Nombre, Telefono, Email)
            VALUES ($id, $nombre, $telefono, $email)";
        command.Parameters.AddWithValue("$id", paciente.Id);
        command.Parameters.AddWithValue("$nombre", paciente.Nombre);
        command.Parameters.AddWithValue("$telefono", paciente.Telefono);
        command.Parameters.AddWithValue("$email", paciente.Email);

        command.ExecuteNonQuery();

        connection.Close();

        return Task.CompletedTask;
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

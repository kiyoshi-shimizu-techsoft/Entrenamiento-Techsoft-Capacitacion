using Bisoft.Entrenamiento.Dominio.Entities;
using System;
using System.Threading.Tasks;

namespace Bisoft.Entrenamiento.Dominio.Repositories
{
    public interface IPacienteRepository
    {
        Task AgregarPaciente(Paciente paciente);
        Task<Paciente> ObtenerPacientePorId(Guid id);
        Task GuardarCambios();
    }
}

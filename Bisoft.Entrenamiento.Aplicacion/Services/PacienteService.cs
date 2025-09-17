using Bisoft.Entrenamiento.Dominio.Entities;
using Bisoft.Entrenamiento.Dominio.Repositories;

namespace Bisoft.Entrenamiento.Aplicacion.Services;
public class PacienteService
{
    private readonly IPacienteRepository _pacienteRepository;
    public PacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }
    public async Task<Guid> CrearPaciente(string nombre, string telefono, string email)
    {
        var paciente = new Paciente(nombre, telefono, email);
        await _pacienteRepository.AgregarPaciente(paciente);
        await _pacienteRepository.GuardarCambios();
        return paciente.Id;
    }
    public async Task ActualizarContactoPaciente(Guid pacienteId, string telefono, string email)
    {
        var paciente = await _pacienteRepository.ObtenerPacientePorId(pacienteId);
        if (paciente == null)
        {
            throw new ArgumentException("Paciente no encontrado");
        }
        paciente.ActualizarContacto(telefono, email);
        // Asumimos que el repositorio maneja el seguimiento de cambios
    }
}

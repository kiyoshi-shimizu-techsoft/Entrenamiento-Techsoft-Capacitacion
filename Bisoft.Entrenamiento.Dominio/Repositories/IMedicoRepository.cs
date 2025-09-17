using Bisoft.Entrenamiento.Dominio.Entities;
using System.Threading.Tasks;

namespace Bisoft.Entrenamiento.Dominio.Repositories
{
    public interface IMedicoRepository
    {
        Task AgregarMedico(Medico medico);
    }
}

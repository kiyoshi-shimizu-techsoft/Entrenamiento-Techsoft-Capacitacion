using Bisoft.Entrenamiento.Dominio.Entities.Base;
using System;

namespace Bisoft.Entrenamiento.Dominio.Entities
{
    public class Medico : Persona
    {
        public string Especialidad { get; }
        public Medico(string nombre, string especialidad, string telefono, string email)
            : base(nombre, telefono, email)
        {
            Especialidad = especialidad;
        }
    }
}

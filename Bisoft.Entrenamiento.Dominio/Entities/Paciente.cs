using Bisoft.Entrenamiento.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bisoft.Entrenamiento.Dominio.Entities
{
    public class Paciente : Persona
    {
        public Paciente(string nombre, string telefono, string email) 
            : base(nombre, telefono, email)
        {
        }
    }
}

using System;

namespace Bisoft.Entrenamiento.Dominio.Entities.Base
{
    public abstract class Persona
    {
        public Guid Id { get; }
        public string Nombre { get; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }
        protected Persona(string nombre, string telefono, string email)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }
        public void ActualizarContacto(string telefono, string email)
        {
            ValidarEmail(email);
            Telefono = telefono;
            Email = email;
        }
        private static void ValidarEmail(string email)
        {
            if(!email.Contains("@"))
            {
                throw new ArgumentException("Email no es válido");
            }
        }
    }
}

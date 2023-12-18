using System.Data;

namespace Entidades
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public List<string> Contraseñas { get; set; }
        public DateTime FechaDeUltimaModificacion { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string email, string contraseña) {
            Nombre = nombre;
            Email = email;
            Contraseñas = new List<string> {contraseña};
        }

        public bool modificarContraseña(string nuevaContraseña)
        {
            if(contraseñaDiferenteALaActual(nuevaContraseña))
            {
                Contraseñas.Add(nuevaContraseña);
                FechaDeUltimaModificacion = DateTime.Now;
                return true;
            }
            return false;
        }

        private bool contraseñaDiferenteALaActual(string nuevaContraseña)
        {
            return nuevaContraseña != Contraseñas.Last();
        }


        public string obtenerEmail()
        {
            return Email;
        }

    }
}
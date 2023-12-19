using Entidades;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace Gestor_de_contraseñas
{

    public class Controller
    {
        private readonly IValidadora validadora;
        private readonly ISerializadora serializadora;
        private readonly IEncriptadora encriptadora;

        public Controller(IValidadora validadora, ISerializadora serializadora, IEncriptadora encriptadora)
        {
            this.validadora = validadora ?? throw new ArgumentNullException(nameof(validadora));
            this.serializadora = serializadora ?? throw new ArgumentNullException(nameof(serializadora));
            this.encriptadora = encriptadora ?? throw new ArgumentNullException(nameof(encriptadora));
        }

        public bool altaUsuario(string nombre, string email, string contraseña)
        {
            string contaseñaEncriptada = encriptadora.Encrypt(contraseña); 

            Usuario usuario = new Usuario(nombre, email, contaseñaEncriptada);

            serializadora.altaUsuario(usuario);

            return true;
        }

        public List<string> contraseñasDelUsuario(string nombre, string contraseña)
        {
            contraseña = encriptadora.Encrypt(contraseña);

            try
            {
                Usuario usuario = serializadora.obtenerUsuarios().First(x => x.Nombre == nombre && x.Contraseñas.Last() == contraseña);

                List<string> contraseñas = new List<string>();

                foreach (string contra in usuario.Contraseñas)
                {
                    string contraDesencriptada = encriptadora.Decrypt(contra);
                    contraseñas.Add(contraDesencriptada);
                }

                return contraseñas;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Usuario no encontrado.", ex);
            }
        }

        public void cambiarContraseña(string nombre, string contraseña, string contraseñaNueva)
        {
            contraseña = encriptadora.Encrypt(contraseña);

            try
            {
                Usuario usuario = serializadora.obtenerUsuarios().First(x => x.Nombre == nombre && x.Contraseñas.Last() == contraseña);
                string contraseñaNuevaEncriptada = encriptadora.Encrypt(contraseñaNueva);
                usuario.modificarContraseña(contraseñaNuevaEncriptada);

                serializadora.altaUsuario(usuario);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Usuario no encontrado.", ex);
            }
        }

    }

    public class Validadora : IValidadora
    {
        private readonly ISerializadora serializadora;
        public Validadora(ISerializadora serializadora)
        {
            this.serializadora = serializadora;
        }

        //Si hay un usuario con ese mail registrado, devuelve true
        public bool validarMailExistente(string email)
        {
            foreach (Usuario usuario in serializadora.obtenerUsuarios())
            {
                if (usuario.Email == email)
                    return true;
            }
            return false;
        }

        //Si hay un usuario con el nombre registrado, devuelve true
        public bool validarNombre(string nombre)
        {
            foreach (Usuario usuario in serializadora.obtenerUsuarios())
            {
                if (usuario.Nombre == nombre)
                    return true;
            }
            return false;
        }

        public bool validarMail(string email)
        {
            // El mail debe ser cualquier letra o numero y alguna caracter especial, pero solo acepta dominio
            // gmail u outlook
            string mailValido = @"^[a-zA-Z0-9._+-]+@(gmail\.com|outlook\.com)$";

            Regex regex = new Regex(mailValido);

            return regex.IsMatch(email);
        }

        public bool validarContraseña(string contraseña)
        {
            // Expresión regular para validar que la contraseña
            // tenga mayusculas, minusculas, y caracteres especiales,
            // de una longitud, al menos, de 8 caracteres
            string constraseñaValida = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d._+-]{8,}$";

            Regex regex = new Regex(constraseñaValida);

            return regex.IsMatch(contraseña);
        }
    }


    public class Serializadora: ISerializadora
    {

        public bool altaUsuario(Usuario usuario)
        {
            List<Usuario> usuarios = obtenerUsuarios();

            if (usuarios.Find(x => x.Nombre == usuario.Nombre) != null)
                usuarios.Remove(usuarios.Find(x => x.Nombre == usuario.Nombre));

            usuarios.Add(usuario);

            string jsonUsuariosActualizados = JsonSerializer.Serialize(usuarios);

            string path = "D:\\Documentos\\usuarios.json";

            File.WriteAllText(path, jsonUsuariosActualizados);

            return true;
        }

        public List<Usuario> obtenerUsuarios()
        {
            string path = "D:\\Documentos\\usuarios.json";

            try
            {
                // Verificar si el archivo existe antes de intentar leerlo
                if (!File.Exists(path))
                {
                    return new List<Usuario>();
                }

                string contenidoActual = File.ReadAllText(path, Encoding.UTF8);

                List<Usuario> usuariosActuales = string.IsNullOrWhiteSpace(contenidoActual)
                    ? new List<Usuario>()
                    : JsonSerializer.Deserialize<List<Usuario>>(contenidoActual);

                return usuariosActuales;
            }
            catch (JsonException ex)
            {
                return new List<Usuario>();
            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }
    }

    public class EncryptMD5 : IEncriptadora
    {
        public string Encrypt(string contraseña)
        {
            string hash = "coding";

            byte[] data = UTF8Encoding.UTF8.GetBytes(contraseña);

            MD5 md5 = MD5.Create();

            TripleDES tripledes = TripleDES.Create();
            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();

            byte[] contraseñaEncriptada = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(contraseñaEncriptada);
        }
        public string Decrypt(string contraseñaEncriptada)
        {
            string hash = "coding";

            byte[] data = Convert.FromBase64String(contraseñaEncriptada);

            MD5 md5 = MD5.Create();

            TripleDES tripledes = TripleDES.Create();
            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateDecryptor();

            byte[] contraseña = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(contraseña);
        }
    }
}
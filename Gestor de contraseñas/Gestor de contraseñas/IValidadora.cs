using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_contraseñas
{
    public interface IValidadora
    {
        bool validarMailExistente(string email);
        bool validarNombre(string nombre);
        bool validarMail(string email);
        bool validarContraseña(string contraseña);

    }
    public interface ISerializadora
    {
        bool altaUsuario(Usuario usuario);
        List<Usuario> obtenerUsuarios();

    }

    public interface IEncriptadora
    {
        string Encrypt(string contraseña);
        string Decrypt(string contraseñaEncriptada);
    }
}

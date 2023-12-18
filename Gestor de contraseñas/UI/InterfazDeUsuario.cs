using Entidades;
using Gestor_de_contraseñas;
using System;

ISerializadora serializadora = new Serializadora();
IValidadora validadora = new Validadora(serializadora);
IEncriptadora encryptor = new EncryptMD5();

Controller controller = new Controller(validadora, serializadora, encryptor);

string val = "s";


while (val == "s")
{
    bool validador = true;
    string nombre = "";
    string email = "";
    string contraseña = "";
    
    do
    {
        Console.WriteLine("Ingrese un nombre de usuario:");
        nombre = Console.ReadLine();

        if (validadora.validarNombre(nombre))
        {
            Console.WriteLine("ERROR! \nEl nombre ya existe");
            Thread.Sleep(5000);
            validador = false;
        }
        else
            validador = true;

        Console.Clear();

    } while(!validador);

    do
    {
        Console.WriteLine("Ingrese el email:");
        email = Console.ReadLine();

        if (!validadora.validarMail(email))
        {
            Console.WriteLine("ERROR! \nRepete el formato de mail! (usuario @ gmail/outlook .com)");
            Thread.Sleep(5000);
            validador = false;
        }
        else if (validadora.validarMailExistente(email))
        {
            Console.WriteLine("ERROR! \n El mail se encuentra registrado");
            Thread.Sleep(5000);
            validador = false;
        }
        else
            validador = true;

        Console.Clear();

    } while(!validador);

    do
    {

        Console.WriteLine("Contraseña: ");
        contraseña = Console.ReadLine();

        if (!validadora.validarContraseña(contraseña))
        {
            Console.WriteLine("ERROR! \n Repete el formato de contraseña: \n 8 carcateres," +
                " mayusculas, minusculas y caracteres especiales (+ , . - )");
            Thread.Sleep(5000);
            validador = false;
        }
        else
            validador = true;

        Console.Clear();

    } while (!validador);

    Resultado resultado = controller.altaUsuario(nombre, email, contraseña);

    switch (resultado)
    {
        //case Resultado.Mail_invalido: Console.WriteLine("El mail es invalido"); break;
        //case Resultado.Mail_existente: Console.WriteLine("El mail ya está registrado"); break;
        //case Resultado.Contraseña_invalida: Console.WriteLine("La contraseña es invalida"); break;
        //case Resultado.Nombre_registrado: Console.WriteLine("El nombre ya esta registrado"); break;
        case Resultado.Carga_exitosa: Console.WriteLine("El alta de usuario ha sido exitosa"); break;      
    }

    Console.Clear();
    Console.WriteLine("Desea seguir cargando?");
    val = Console.ReadLine();
}
using Entidades;
using Gestor_de_contraseñas;
using System;
using System.ComponentModel.DataAnnotations;

ISerializadora serializadora = new Serializadora();
IValidadora validadora = new Validadora(serializadora);
IEncriptadora encryptor = new EncryptMD5();

Controller controller = new Controller(validadora, serializadora, encryptor);

string continuar = "s";

while (continuar == "s")
{
    Console.WriteLine("¿Que desea realizar?\n1. (alta de usuario)\n2. (obtener historial de contraseñas)\n3. (cambiar contraseña)");
    int valorDeLaAccion = Convert.ToInt16(Console.ReadLine());

    Accion accion = (Accion)valorDeLaAccion;

    switch (accion)
    {
        case Accion.Alta_Usuario:
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

                } while (!validador);

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

                } while (!validador);

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

                bool resultado = controller.altaUsuario(nombre, email, contraseña);


                Console.WriteLine("El alta de usuario ha sido exitosa");

                Console.Clear();
        }
        break;

        case Accion.Obtener_historial_De_Contraseñas:
        {
                do
                {
                    Console.WriteLine("Ingrese un nombre de usuario para obtener la contraseña:");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese tambien la contraseña:");
                    string contraseña = Console.ReadLine();

                    if (!validadora.validarNombre(nombre))
                    {
                        Console.WriteLine("ERROR! \nEl nombre no existe");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    else
                    {
                        List<string> contraseñasObtenidas = controller.contraseñaUsuario(nombre, contraseña);

                        Console.WriteLine("La/s contraseña/s es/son: \n");
                        foreach(string contraseñita in contraseñasObtenidas)
                        {
                            Console.WriteLine(contraseñita);
                        }
                    
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    }
                } while (true);
        }
        break;

        case Accion.Cambiar_Contraseña: 
        {
                
        }
        break;



    }

    Console.WriteLine("Desea continuar? (s/n)");
    continuar = Console.ReadLine().ToLower();
}


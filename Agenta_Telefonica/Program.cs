using System;
using System.Collections.Generic;

class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(string nombre, string telefono, string email, string direccion)
    {
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}\nTeléfono: {Telefono}\nEmail: {Email}\nDirección: {Direccion}\n";
    }
}

class AgendaTelefonica
{
    private List<Contacto> contactos;
    private readonly Scanner scanner;

    public AgendaTelefonica()
    {
        contactos = new List<Contacto>();
        scanner = new Scanner();
    }

    public void AgregarContacto()
    {
        Console.WriteLine("\n========= Agregar Nuevo Contacto ==========");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        contactos.Add(new Contacto(nombre, telefono, email, direccion));
        Console.WriteLine("¡Contacto agregado exitosamente!");
    }

    public void BuscarContacto()
    {
        Console.WriteLine("\n=============== Buscar Contacto =============");
        Console.Write("Ingrese el nombre a buscar: ");
        string nombre = Console.ReadLine();

        bool encontrado = false;
        foreach (var contacto in contactos)
        {
            if (contacto.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nContacto encontrado:");
                Console.WriteLine(contacto);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
        }
    }

    public void MostrarContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("\nNo hay contactos en la agenda.\n ");
            return;
        }

        Console.WriteLine("\n============ Lista de Contactos ================\n");
        for (int i = 0; i < contactos.Count; i++)
        {
            Console.WriteLine($"\nContacto #{i + 1}");
            Console.WriteLine(contactos[i]);
        }
    }

    public static void Main(string[] args)
    {
        AgendaTelefonica agenda = new AgendaTelefonica();
        int opcion;

        do
        {
            Console.WriteLine("\n=============== AGENDA TELEFÓNICA ================\n");
            Console.WriteLine("1. Agregar contacto\n");
            Console.WriteLine("2. Buscar contacto\n");
            Console.WriteLine("3. Mostrar todos los contactos\n");
            Console.WriteLine("4. Salir \n");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    agenda.AgregarContacto();
                    break;
                case 2:
                    agenda.BuscarContacto();
                    break;
                case 3:
                    agenda.MostrarContactos();
                    break;
                case 4:
                    Console.WriteLine("¡Hasta luego gracias por utilizar nuestro sistema 😊!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 4);
    }
}


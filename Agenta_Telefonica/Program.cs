using System;
using System.Collections.Generic;
using System.Linq;
 
// Define la clase Contacto que representa la información básica de un contacto
class Contacto
{
    // Propiedades públicas para almacenar los datos de un contacto
    public string Nombre { get; set; } // Nombre del contacto
    public string Telefono { get; set; } // Número de teléfono del contacto
    public string Email { get; set; } // Dirección de correo electrónico del contacto
    public string Direccion { get; set; } // Dirección física del contacto
 
    // Constructor que inicializa un nuevo objeto Contacto con los datos proporcionados
    public Contacto(string nombre, string telefono, string email, string direccion)
    {
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }
 
    // Sobrescribe el método ToString para mostrar los detalles del contacto de manera clara
    public override string ToString()
    {
        return $"Nombre: {Nombre}\nTeléfono: {Telefono}\nEmail: {Email}\nDirección: {Direccion}\n";
    }
}
 
// Define la clase AgendaTelefonica para gestionar contactos
class AgendaTelefonica
{
    // Lista privada para almacenar objetos Contacto
    private List<Contacto> contactos;
 
    // Constructor que inicializa una lista vacía para los contactos
    public AgendaTelefonica()
    {
        contactos = new List<Contacto>();
    }
 
    // Método para agregar un nuevo contacto a la agenda
    public void AgregarContacto()
    {
        Console.WriteLine("\n============ Agregar Nuevo Contacto =======\n");
        // Solicita al usuario que ingrese los detalles del contacto
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
 
        // Crea un nuevo objeto Contacto y lo agrega a la lista
        contactos.Add(new Contacto(nombre, telefono, email, direccion));
        Console.WriteLine("¡Contacto agregado exitosamente!");
    }
 
    // Método para buscar un contacto por nombre
    public void BuscarContacto()
    {
        Console.WriteLine("\n=== Buscar Contacto ===");
        // Solicita al usuario el nombre o parte del nombre para buscar
        Console.Write("Ingrese el nombre a buscar: ");
        string nombre = Console.ReadLine();
 
        bool encontrado = false; // Bandera para verificar si se encuentra algún contacto
 
        // Itera sobre la lista de contactos para buscar coincidencias
        foreach (var contacto in contactos)
        {
            // Compara el nombre ingresado con los nombres en la lista (sin diferenciar mayúsculas/minúsculas)
            if (contacto.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
            {
                // Muestra el contacto encontrado
                Console.WriteLine("\nContacto encontrado:");
                Console.WriteLine(contacto);
                encontrado = true; // Actualiza la bandera si se encuentra un contacto
            }
        }
 
        // Muestra un mensaje si no se encuentra ningún contacto
        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
        }
    }
 
    // Método para mostrar todos los contactos en la agenda
    public void MostrarContactos()
    {
        // Verifica si la lista de contactos está vacía
        if (contactos.Count == 0)
        {
            Console.WriteLine("\nNo hay contactos en la agenda.");
            return;
        }
 
        // Itera sobre la lista y muestra cada contacto con su índice
        Console.WriteLine("\n=== Lista de Contactos ===");
        for (int i = 0; i < contactos.Count; i++)
        {
            Console.WriteLine($"\nContacto #{i + 1}");
            Console.WriteLine(contactos[i]);
        }
    }
 
    // Método para generar un informe estadístico de los contactos
    public void GenerarInforme()
    {
        Console.WriteLine("\n=== Informe de Contactos ===");
 
        // Verifica si la lista de contactos está vacía
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos en la agenda.");
            return;
        }
 
        // Calcula y muestra la cantidad total de contactos
        int totalContactos = contactos.Count;
        Console.WriteLine($"Total de contactos: {totalContactos}");
 
        // Agrupa los contactos por la inicial del nombre y ordena alfabéticamente
        var contactosPorInicial = contactos
            .GroupBy(c => c.Nombre[0].ToString().ToUpper()) // Agrupa por la primera letra
            .OrderBy(g => g.Key); // Ordena los grupos alfabéticamente
 
        // Muestra el desglose de contactos por inicial
        Console.WriteLine("\nDesglose por inicial del nombre:");
        foreach (var grupo in contactosPorInicial)
        {
            Console.WriteLine($"  {grupo.Key}: {grupo.Count()} contacto(s)");
        }
 
        // Calcula la longitud promedio de los nombres
        double longitudPromedio = contactos.Average(c => c.Nombre.Length);
        Console.WriteLine($"\nLongitud promedio de los nombres: {longitudPromedio:F2} caracteres");
 
        // Calcula y muestra la cantidad de emails únicos
        var emailsUnicos = contactos.Select(c => c.Email).Distinct().Count();
        Console.WriteLine($"Total de emails únicos: {emailsUnicos}");
    }
 
    // Método principal para interactuar con el usuario y gestionar la agenda
    public static void Main(string[] args)
    {
        // Crea una instancia de la agenda
        AgendaTelefonica agenda = new AgendaTelefonica();
        int opcion; // Variable para almacenar la opción seleccionada por el usuario
 
        // Ciclo para mostrar el menú de opciones hasta que el usuario elija salir
        do
        {
            Console.WriteLine("\n=== AGENDA TELEFÓNICA ===\n");
            Console.WriteLine("1. Agregar contacto\n");
            Console.WriteLine("2. Buscar contacto \n");
            Console.WriteLine("3. Mostrar todos los contactos\n");
            Console.WriteLine("4. Generar informe \n");
            Console.WriteLine("5. Salir \n");
            Console.Write("Seleccione una opción: ");
 
            // Valida la entrada del usuario y convierte la entrada a un número entero
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }
 
            // Ejecuta la acción correspondiente según la opción seleccionada
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
                    agenda.GenerarInforme();
                    break;
                case 5:
                    Console.WriteLine("¡Hasta luego gracias por utilizar la agenta telefonica!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 5); // El ciclo se repite hasta que el usuario elija salir
    }
}
 


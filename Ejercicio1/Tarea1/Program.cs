using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

// Clase que representa a un paciente
class Paciente
{
    public int Id { get; } // Identificador único del paciente

    // SemaphoreSlim para controlar el acceso a los médicos (4 disponibles)
    private static SemaphoreSlim medicos = new SemaphoreSlim(4);

    // Random para asignar un médico aleatorio
    private static Random rand = new Random();

    // Constructor de la clase Paciente
    public Paciente(int id)
    {
        Id = id; // Asigna el ID al paciente
    }

    // Método asíncrono que simula la atención de un paciente
    public async Task AtenderAsync()
    {
        try
        {
            // Mensaje de llegada del paciente
            Console.WriteLine($"Paciente {Id} ha llegado al hospital.");

            // Espera a que haya un médico disponible (usa SemaphoreSlim para controlar el acceso)
            await medicos.WaitAsync();

            // Asigna un médico aleatorio (entre 1 y 4)
            int medicoAsignado = rand.Next(1, 5);
            Console.WriteLine($"Paciente {Id} es atendido por el médico {medicoAsignado}.");

            // Simula el tiempo de consulta (10 segundos)
            await Task.Delay(10000);

            // Mensaje de finalización de la consulta
            Console.WriteLine($"Paciente {Id} ha terminado la consulta y sale del hospital.");
        }
        catch (Exception ex)
        {
            // Manejo de excepciones en caso de error durante la atención
            Console.WriteLine($"Error al atender al paciente {Id}: {ex.Message}");
        }
        finally
        {
            // Libera el médico para que pueda atender a otro paciente
            medicos.Release();
        }
    }
}

// Clase principal que simula el funcionamiento del hospital
class Hospital
{
    // Método principal asíncrono
    public static async Task Main()
    {
        // Lista para almacenar las tareas de atención de los pacientes
        List<Task> tareas = new List<Task>();

        // Bucle para generar 4 pacientes
        for (int i = 1; i <= 4; i++)
        {
            // Crea un nuevo paciente con un ID único
            Paciente paciente = new Paciente(i);

            // Inicia la tarea de atención del paciente y la añade a la lista
            tareas.Add(paciente.AtenderAsync());

            // Espera 2 segundos antes de generar el siguiente paciente
            await Task.Delay(2000);
        }

        // Espera a que todas las tareas de atención se completen
        await Task.WhenAll(tareas);

        // Mensaje final indicando que todos los pacientes han sido atendidos
        Console.WriteLine("Todos los pacientes han sido atendidos.");
    }
}

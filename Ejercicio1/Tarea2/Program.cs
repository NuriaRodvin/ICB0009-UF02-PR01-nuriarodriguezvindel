using System;
using System.Collections.Generic; // Añade esta línea
using System.Threading.Tasks;

public class Paciente
{
    public int Id { get; } // Identificador único
    public int LlegadaHospital { get; } // Tiempo de llegada al hospital
    public int TiempoConsulta { get; } // Tiempo de consulta
    public string Estado { get; set; } // Estado del paciente

    // Constructor
    public Paciente(int id, int llegadaHospital, int tiempoConsulta)
    {
        Id = id;
        LlegadaHospital = llegadaHospital;
        TiempoConsulta = tiempoConsulta;
        Estado = "Espera"; // Estado inicial
    }

    // Método para simular la atención del paciente
    public async Task AtenderAsync()
    {
        Estado = "Consulta";
        Console.WriteLine($"Paciente {Id} ha llegado. Estado: {Estado}");
        await Task.Delay(TiempoConsulta * 1000); // Simula el tiempo de consulta
        Estado = "Finalizado";
        Console.WriteLine($"Paciente {Id} ha terminado la consulta. Estado: {Estado}");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Random random = new Random();
        List<Task> tareas = new List<Task>(); // Usa List<Task> aquí

        for (int i = 1; i <= 4; i++)
        {
            int id = random.Next(1, 101); // ID aleatorio entre 1 y 100
            int tiempoConsulta = random.Next(5, 16); // Tiempo de consulta entre 5 y 15 segundos
            Paciente paciente = new Paciente(id, i * 2, tiempoConsulta);

            tareas.Add(paciente.AtenderAsync());
            await Task.Delay(2000); // Llega un paciente cada 2 segundos
        }

        await Task.WhenAll(tareas); // Espera a que todos los pacientes sean atendidos
        Console.WriteLine("Todos los pacientes han sido atendidos.");
    }
}
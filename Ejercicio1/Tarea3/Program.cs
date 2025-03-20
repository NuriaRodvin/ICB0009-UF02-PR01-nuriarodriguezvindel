using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Paciente
{
    public int Id { get; } // Identificador único
    public int LlegadaHospital { get; } // Tiempo de llegada al hospital
    public int TiempoConsulta { get; } // Tiempo de consulta
    public string Estado { get; set; } // Estado del paciente
    public Stopwatch TiempoEspera { get; } // Tiempo de espera

    // Constructor
    public Paciente(int id, int llegadaHospital, int tiempoConsulta)
    {
        Id = id;
        LlegadaHospital = llegadaHospital;
        TiempoConsulta = tiempoConsulta;
        Estado = "Espera"; // Estado inicial
        TiempoEspera = new Stopwatch();
        TiempoEspera.Start(); // Inicia el tiempo de espera
    }

    // Método para simular la atención del paciente
    public async Task AtenderAsync()
    {
        Estado = "Consulta";
        TiempoEspera.Stop(); // Detiene el tiempo de espera
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}. Duración Espera: {TiempoEspera.Elapsed.Seconds} segundos.");
        await Task.Delay(TiempoConsulta * 1000); // Simula el tiempo de consulta
        Estado = "Finalizado";
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}. Duración Consulta: {TiempoConsulta} segundos.");
    }
}


class Program
{
    static async Task Main(string[] args)
    {
        Random random = new Random();
        List<Task> tareas = new List<Task>();

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
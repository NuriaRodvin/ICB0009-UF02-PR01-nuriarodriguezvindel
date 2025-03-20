using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Paciente
{
    public int Id { get; } // Identificador único
    public int LlegadaHospital { get; } // Tiempo de llegada al hospital
    public int TiempoConsulta { get; } // Tiempo de consulta
    public bool RequiereDiagnostico { get; } // ¿Requiere diagnóstico?
    public string Estado { get; set; } // Estado del paciente
    public Stopwatch TiempoEspera { get; } // Tiempo de espera

    // Constructor
    public Paciente(int id, int llegadaHospital, int tiempoConsulta, bool requiereDiagnostico)
    {
        Id = id;
        LlegadaHospital = llegadaHospital;
        TiempoConsulta = tiempoConsulta;
        RequiereDiagnostico = requiereDiagnostico;
        Estado = "EsperaConsulta"; // Estado inicial
        TiempoEspera = new Stopwatch();
        TiempoEspera.Start(); // Inicia el tiempo de espera
    }

    // Método para simular la atención del paciente
    public async Task AtenderAsync(SemaphoreSlim semaforoDiagnostico)
    {
        Estado = "Consulta";
        TiempoEspera.Stop(); // Detiene el tiempo de espera
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}. Duración Espera: {TiempoEspera.Elapsed.Seconds} segundos.");
        await Task.Delay(TiempoConsulta * 1000); // Simula el tiempo de consulta

        if (RequiereDiagnostico)
        {
            Estado = "EsperaDiagnostico";
            Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}.");
            await semaforoDiagnostico.WaitAsync(); // Espera una máquina de diagnóstico disponible
            Estado = "Diagnostico";
            Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}.");
            await Task.Delay(15000); // Simula el tiempo de diagnóstico
            semaforoDiagnostico.Release(); // Libera la máquina de diagnóstico
        }

        Estado = "Finalizado";
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}.");
    }
}



class Program
{
    static async Task Main(string[] args)
    {
        Random random = new Random();
        List<Task> tareas = new List<Task>();
        SemaphoreSlim semaforoDiagnostico = new SemaphoreSlim(2); // 2 máquinas de diagnóstico

        for (int i = 1; i <= 4; i++)
        {
            int id = random.Next(1, 101); // ID aleatorio entre 1 y 100
            int tiempoConsulta = random.Next(5, 16); // Tiempo de consulta entre 5 y 15 segundos
            bool requiereDiagnostico = random.Next(2) == 1; // 50% de probabilidad de requerir diagnóstico
            Paciente paciente = new Paciente(id, i * 2, tiempoConsulta, requiereDiagnostico);

            tareas.Add(paciente.AtenderAsync(semaforoDiagnostico));
            await Task.Delay(2000); // Llega un paciente cada 2 segundos
        }

        await Task.WhenAll(tareas); // Espera a que todos los pacientes sean atendidos
        Console.WriteLine("Todos los pacientes han sido atendidos.");
    }
}
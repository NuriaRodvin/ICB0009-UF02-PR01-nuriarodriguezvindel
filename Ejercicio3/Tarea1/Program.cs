using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class Paciente
{
    public int Id { get; } // Identificador único
    public int LlegadaHospital { get; } // Tiempo de llegada al hospital
    public int TiempoConsulta { get; } // Tiempo de consulta
    public bool RequiereDiagnostico { get; } // ¿Requiere diagnóstico?
    public int Prioridad { get; } // Nivel de prioridad (1: Emergencia, 2: Urgencia, 3: Consulta general)
    public string Estado { get; set; } // Estado del paciente
    public Stopwatch TiempoEspera { get; } // Tiempo de espera
    public int TiempoTotalEnHospital { get; set; } // Tiempo total en el hospital

    // Constructor
    public Paciente(int id, int llegadaHospital, int tiempoConsulta, bool requiereDiagnostico)
    {
        Id = id;
        LlegadaHospital = llegadaHospital;
        TiempoConsulta = tiempoConsulta;
        RequiereDiagnostico = requiereDiagnostico;
        Prioridad = new Random().Next(1, 4); // Prioridad aleatoria entre 1 y 3
        Estado = "EsperaConsulta"; // Estado inicial
        TiempoEspera = new Stopwatch();
        TiempoEspera.Start(); // Inicia el tiempo de espera
    }

    // Método para simular la atención del paciente
    public async Task AtenderAsync(SemaphoreSlim semaforoConsulta, SemaphoreSlim semaforoDiagnostico, Queue<Paciente> colaDiagnostico)
    {
        await semaforoConsulta.WaitAsync(); // Espera una consulta médica disponible
        Estado = "Consulta";
        TiempoEspera.Stop(); // Detiene el tiempo de espera
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Prioridad: {Prioridad}. Estado: {Estado}. Duración Espera: {TiempoEspera.Elapsed.Seconds} segundos.");
        await Task.Delay(TiempoConsulta * 1000); // Simula el tiempo de consulta

        if (RequiereDiagnostico)
        {
            Estado = "EsperaDiagnostico";
            Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Prioridad: {Prioridad}. Estado: {Estado}.");
            colaDiagnostico.Enqueue(this); // Añade el paciente a la cola de diagnóstico

            while (colaDiagnostico.Peek() != this) // Espera a ser el primero en la cola
            {
                await Task.Delay(100);
            }

            await semaforoDiagnostico.WaitAsync(); // Espera una máquina de diagnóstico disponible
            Estado = "Diagnostico";
            Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Prioridad: {Prioridad}. Estado: {Estado}.");
            await Task.Delay(15000); // Simula el tiempo de diagnóstico
            semaforoDiagnostico.Release(); // Libera la máquina de diagnóstico
            colaDiagnostico.Dequeue(); // Saca al paciente de la cola de diagnóstico
        }

        Estado = "Finalizado";
        TiempoTotalEnHospital = (int)(DateTime.Now - DateTime.Now.AddSeconds(-LlegadaHospital)).TotalSeconds; // Calcula el tiempo total en el hospital
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Prioridad: {Prioridad}. Estado: {Estado}. Tiempo total en el hospital: {TiempoTotalEnHospital} segundos.");
        semaforoConsulta.Release(); // Libera la consulta médica para el siguiente paciente
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Random random = new Random();
        List<Task> tareas = new List<Task>();
        SemaphoreSlim semaforoConsulta = new SemaphoreSlim(4); // 4 consultas médicas
        SemaphoreSlim semaforoDiagnostico = new SemaphoreSlim(2); // 2 máquinas de diagnóstico
        Queue<Paciente> colaDiagnostico = new Queue<Paciente>(); // Cola para mantener el orden de llegada

        int pacienteId = 1; // Contador de pacientes

        // Generador de pacientes infinito
        while (true)
        {
            int tiempoConsulta = random.Next(5, 16); // Tiempo de consulta entre 5 y 15 segundos
            bool requiereDiagnostico = random.Next(2) == 1; // 50% de probabilidad de requerir diagnóstico
            Paciente paciente = new Paciente(pacienteId++, DateTime.Now.Second, tiempoConsulta, requiereDiagnostico);

            tareas.Add(paciente.AtenderAsync(semaforoConsulta, semaforoDiagnostico, colaDiagnostico));
            await Task.Delay(2000); // Llega un paciente cada 2 segundos
        }
    }
}
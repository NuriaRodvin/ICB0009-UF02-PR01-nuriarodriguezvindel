using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Prioridad: {Prioridad}. Estado: {Estado}.");
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

        List<Paciente> pacientes = new List<Paciente>();

        // Generar 20 pacientes
        for (int i = 1; i <= 20; i++)
        {
            int id = random.Next(1, 101); // ID aleatorio entre 1 y 100
            int tiempoConsulta = random.Next(5, 16); // Tiempo de consulta entre 5 y 15 segundos
            bool requiereDiagnostico = random.Next(2) == 1; // 50% de probabilidad de requerir diagnóstico
            Paciente paciente = new Paciente(id, i * 2, tiempoConsulta, requiereDiagnostico);
            pacientes.Add(paciente);
        }

        // Ordenar pacientes por prioridad y tiempo de llegada
        pacientes.Sort((p1, p2) =>
        {
            if (p1.Prioridad == p2.Prioridad)
                return p1.LlegadaHospital.CompareTo(p2.LlegadaHospital); // Orden de llegada si tienen la misma prioridad
            return p1.Prioridad.CompareTo(p2.Prioridad); // Orden por prioridad
        });

        // Atender a los pacientes en orden de prioridad
        foreach (var paciente in pacientes)
        {
            tareas.Add(paciente.AtenderAsync(semaforoConsulta, semaforoDiagnostico, colaDiagnostico));
            await Task.Delay(2000); // Llega un paciente cada 2 segundos
        }

        await Task.WhenAll(tareas); // Espera a que todos los pacientes sean atendidos
        Console.WriteLine("Todos los pacientes han sido atendidos.");
    }
}
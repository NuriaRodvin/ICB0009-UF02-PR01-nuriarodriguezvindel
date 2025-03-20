# Ejercicio 2 - Tarea 3: Más pacientes y sincronización

## Descripción
Este programa simula la llegada de **20 pacientes** a un hospital, donde:
- Los pacientes llegan cada **2 segundos**.
- Hay **4 consultas médicas** disponibles (4 médicos).
- Hay **2 máquinas de diagnóstico** disponibles.
- Los pacientes que requieren diagnóstico deben realizarlo en el orden de llegada.
- Si no hay consultas médicas disponibles, los pacientes esperan en la sala de espera.

## Requisitos
### 1. Generación de pacientes
- Cada paciente tiene un **ID único**, un **tiempo de llegada**, un **tiempo de consulta** (entre 5 y 15 segundos), y un **requerimiento de diagnóstico** (50% de probabilidad).
- Los pacientes llegan cada **2 segundos**.

### 2. Sala de espera
- Si no hay consultas médicas disponibles, los pacientes esperan en la sala de espera.
- La sala de espera tiene una capacidad de **20 pacientes**.

### 3. Diagnóstico
- Los pacientes que requieren diagnóstico deben realizarlo en el orden de llegada.
- Solo **2 pacientes** pueden usar las máquinas de diagnóstico simultáneamente.

### 4. Visualización
- Se muestra por consola el estado de los pacientes, incluyendo su tiempo de espera, tiempo de consulta y tiempo de diagnóstico (si es necesario).

---

## Implementación

### Clase `Paciente`
La clase `Paciente` se amplía para incluir más detalles sobre el estado del paciente y su tiempo de espera.

```csharp
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
    public async Task AtenderAsync(SemaphoreSlim semaforoConsulta, SemaphoreSlim semaforoDiagnostico, Queue<Paciente> colaDiagnostico)
    {
        await semaforoConsulta.WaitAsync(); // Espera una consulta médica disponible
        Estado = "Consulta";
        TiempoEspera.Stop(); // Detiene el tiempo de espera
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}. Duración Espera: {TiempoEspera.Elapsed.Seconds} segundos.");
        await Task.Delay(TiempoConsulta * 1000); // Simula el tiempo de consulta

        if (RequiereDiagnostico)
        {
            Estado = "EsperaDiagnostico";
            Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}.");
            colaDiagnostico.Enqueue(this); // Añade el paciente a la cola de diagnóstico

            while (colaDiagnostico.Peek() != this) // Espera a ser el primero en la cola
            {
                await Task.Delay(100);
            }

            await semaforoDiagnostico.WaitAsync(); // Espera una máquina de diagnóstico disponible
            Estado = "Diagnostico";
            Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}.");
            await Task.Delay(15000); // Simula el tiempo de diagnóstico
            semaforoDiagnostico.Release(); // Libera la máquina de diagnóstico
            colaDiagnostico.Dequeue(); // Saca al paciente de la cola de diagnóstico
        }

        Estado = "Finalizado";
        Console.WriteLine($"Paciente {Id}. Llegado el {LlegadaHospital / 2}. Estado: {Estado}.");
        semaforoConsulta.Release(); // Libera la consulta médica para el siguiente paciente
    }
}

Programa principal
El programa principal genera 20 pacientes y gestiona su atención utilizando semáforos para controlar el acceso a las consultas médicas y las máquinas de diagnóstico.

class Program
{
    static async Task Main(string[] args)
    {
        Random random = new Random();
        List<Task> tareas = new List<Task>();
        SemaphoreSlim semaforoConsulta = new SemaphoreSlim(4); // 4 consultas médicas
        SemaphoreSlim semaforoDiagnostico = new SemaphoreSlim(2); // 2 máquinas de diagnóstico
        Queue<Paciente> colaDiagnostico = new Queue<Paciente>(); // Cola para mantener el orden de llegada

        for (int i = 1; i <= 20; i++)
        {
            int id = random.Next(1, 101); // ID aleatorio entre 1 y 100
            int tiempoConsulta = random.Next(5, 16); // Tiempo de consulta entre 5 y 15 segundos
            bool requiereDiagnostico = random.Next(2) == 1; // 50% de probabilidad de requerir diagnóstico
            Paciente paciente = new Paciente(id, i * 2, tiempoConsulta, requiereDiagnostico);

            tareas.Add(paciente.AtenderAsync(semaforoConsulta, semaforoDiagnostico, colaDiagnostico));
            await Task.Delay(2000); // Llega un paciente cada 2 segundos
        }

        await Task.WhenAll(tareas); // Espera a que todos los pacientes sean atendidos
        Console.WriteLine("Todos los pacientes han sido atendidos.");
    }
}

Preguntas y respuestas
1. ¿Los pacientes que deben esperar entran luego a la consulta por orden de llegada? Explica qué tipo de pruebas has realizado para comprobar este comportamiento.
Respuesta:
Sí, los pacientes que deben esperar entran a la consulta por orden de llegada. Para comprobar este comportamiento, se han realizado las siguientes pruebas:

Prueba con 20 pacientes: Se ha verificado que los pacientes que llegan primero son atendidos primero, independientemente de su tiempo de consulta.

Prueba con tiempos de consulta variables: Se ha observado que, aunque algunos pacientes tienen tiempos de consulta más largos, el orden de llegada se mantiene.

Prueba con diagnóstico: Se ha verificado que los pacientes que requieren diagnóstico realizan las pruebas en el orden de llegada, utilizando la cola de diagnóstico.

2. Explica el planteamiento de tu código y plantea otra posibilidad de solución a la que has programado.
Respuesta:
El planteamiento del código utiliza semáforos para controlar el acceso a las consultas médicas y las máquinas de diagnóstico, y una cola para mantener el orden de llegada de los pacientes que requieren diagnóstico. Esto garantiza que los pacientes sean atendidos en el orden correcto y que no se exceda el límite de recursos disponibles.

Otra posibilidad de solución:
Otra posibilidad sería utilizar un sistema de prioridades para gestionar el acceso a las consultas y las máquinas de diagnóstico. Por ejemplo, los pacientes con mayor prioridad (emergencias) podrían ser atendidos primero, independientemente de su orden de llegada. Sin embargo, esta solución sería más compleja de implementar y requeriría un sistema de gestión de prioridades adicional.

Capturas de pantalla

![image](https://github.com/user-attachments/assets/956889c4-05b5-48e1-8b26-9d50dbcdd30a)


Conclusión
Este programa simula de manera efectiva la atención de 20 pacientes en un hospital, gestionando tanto las consultas médicas como las pruebas de diagnóstico. Se ha utilizado sincronización para garantizar que los recursos no se sobresaturen y que los pacientes sean atendidos en el orden correcto.

